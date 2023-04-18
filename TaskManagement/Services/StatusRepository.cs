using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class StatusRepository : IStatusRepository
    {
        private TaskManagementContext _taskManagementContext;
        public StatusRepository(TaskManagementContext taskManagementContext)
        {
            _taskManagementContext = taskManagementContext;
        }

        public List<TblStatus> AddStatus(TblStatus tblStatus)
        {
            _taskManagementContext.TblStatuses.Add(tblStatus);
            _taskManagementContext.SaveChanges();

            List<TblStatus> tblPriorityNew = _taskManagementContext.TblStatuses.ToList();
            return tblPriorityNew;
        }

        public bool DeleteStatus(int StatusId)
        {
            TblStatus tblStatus = _taskManagementContext.TblStatuses.Where(x => x.StatusId == StatusId).FirstOrDefault();
            if (tblStatus == null)
            {
                return false;
            }
            _taskManagementContext.TblStatuses.Remove(tblStatus);
            _taskManagementContext.SaveChanges();
            return true;
        }

        public List<TblStatus> GetAllStatus()
        {
            return _taskManagementContext.TblStatuses.ToList();
        }

        public List<TblStatus> GetStatusByID(int StatusId)
        {
            return _taskManagementContext.TblStatuses.Where(x => x.StatusId == StatusId).ToList();
        }

        public bool UpdateStatus(TblStatus tblStatus)
        {
            var recordExist = _taskManagementContext.TblStatuses.Where(x => x.StatusId == tblStatus.StatusId).FirstOrDefault();
            if (recordExist != null)
            {
                recordExist.StatusName = tblStatus.StatusName;
                _taskManagementContext.TblStatuses.Add(recordExist);
                _taskManagementContext.Entry(recordExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _taskManagementContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

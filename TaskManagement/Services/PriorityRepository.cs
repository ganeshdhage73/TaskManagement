using System.Collections.Generic;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class PriorityRepository : IPriorityRepository
    {
        private TaskManagementContext _taskManagementContext;
        public PriorityRepository(TaskManagementContext taskManagementContext)
        {
            _taskManagementContext = taskManagementContext;
        }

        public List<TblPriority> AddPriority(TblPriority tblPriority)
        {
            _taskManagementContext.TblPriorities.Add(tblPriority);
            _taskManagementContext.SaveChanges();

            List<TblPriority> tblPriorityNew = _taskManagementContext.TblPriorities.ToList();
            return tblPriorityNew;
        }

        public bool DeletePriority(int PriorityId)
        {
            TblPriority tblPriority = _taskManagementContext.TblPriorities.Where(x => x.PriorityId == PriorityId).FirstOrDefault();
            if (tblPriority == null)
            {
                return false;
            }
            _taskManagementContext.TblPriorities.Remove(tblPriority);
            _taskManagementContext.SaveChanges();
            return true;
        }

        public List<TblPriority> GetAllPriority()
        {
            return _taskManagementContext.TblPriorities.ToList();
        }

        public List<TblPriority> GetPriorityByID(int PriorityId)
        {
            return _taskManagementContext.TblPriorities.Where(x => x.PriorityId == PriorityId).ToList();
        }

        public bool UpdatePriority(TblPriority TblPriority)
        {
            var recordExist = _taskManagementContext.TblPriorities.Where(x => x.PriorityId == TblPriority.PriorityId).FirstOrDefault();
            if (recordExist != null)
            {
                recordExist.PriorityName = TblPriority.PriorityName;
                _taskManagementContext.TblPriorities.Add(recordExist);
                _taskManagementContext.Entry(recordExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _taskManagementContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

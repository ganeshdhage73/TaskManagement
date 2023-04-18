using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class TaskRepository : ITaskRepository
    {
        private TaskManagementContext _taskManagementContext;
        public TaskRepository(TaskManagementContext taskManagementContext)
        {
            _taskManagementContext = taskManagementContext;
        }

        public List<TblTaskActivity> AddTaskActivity(TblTaskActivity tblTaskActivity)
        {
            _taskManagementContext.TblTaskActivities.Add(tblTaskActivity);
            _taskManagementContext.SaveChanges();

            List<TblTaskActivity> tblPriorityNew = _taskManagementContext.TblTaskActivities.ToList();
            return tblPriorityNew;
        }

        public bool DeleteTaskActivity(int TaskId)
        {
            TblTaskActivity tblTaskActivity = _taskManagementContext.TblTaskActivities.Where(x => x.TaskId == TaskId).FirstOrDefault();
            if (tblTaskActivity == null)
            {
                return false;
            }
            _taskManagementContext.TblTaskActivities.Remove(tblTaskActivity);
            _taskManagementContext.SaveChanges();
            return true;
        }

        public List<TblTaskActivityVM> GetAllTaskActivity()
        {
            List<TblTaskActivityVM> tblTaskActivityVM = new List<TblTaskActivityVM>();
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection con = new SqlConnection(_taskManagementContext.Database.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_GetTaskList", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        tblTaskActivityVM = Utils.ConvertToList<TblTaskActivityVM>(ds.Tables[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tblTaskActivityVM;
        }

        public List<TblTaskActivity> GetTaskActivityByID(int TaskId)
        {
            return _taskManagementContext.TblTaskActivities.Where(x => x.TaskId == TaskId).ToList();
        }

        public bool UpdateTaskActivity(TblTaskActivity tblTaskActivity)
        {
            var recordExist = _taskManagementContext.TblTaskActivities.Where(x => x.TaskId == tblTaskActivity.TaskId).FirstOrDefault();
            if (recordExist != null)
            {
                recordExist.TaskName = tblTaskActivity.TaskName;
                recordExist.Priority = tblTaskActivity.Priority;
                recordExist.Status = tblTaskActivity.Status;
                recordExist.EstimatedTime = tblTaskActivity.EstimatedTime;
                recordExist.ActualTime = tblTaskActivity.ActualTime;
                recordExist.AssignedTo = tblTaskActivity.AssignedTo;
                _taskManagementContext.TblTaskActivities.Add(recordExist);
                _taskManagementContext.Entry(recordExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _taskManagementContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

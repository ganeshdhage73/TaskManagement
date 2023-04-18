using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface ITaskRepository
    {
        List<TblTaskActivityVM> GetAllTaskActivity();
        List<TblTaskActivity> GetTaskActivityByID(int TaskId);
        List<TblTaskActivity> AddTaskActivity(TblTaskActivity tblTaskActivity);
        bool UpdateTaskActivity(TblTaskActivity tblTaskActivity);
        bool DeleteTaskActivity(int TaskId);
    }
}

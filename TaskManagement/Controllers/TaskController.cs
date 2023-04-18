using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("GetAllTaskActivity")]
        public List<TblTaskActivityVM> GetAllTaskActivity()
        {
            return _taskRepository.GetAllTaskActivity();
        }

        [HttpGet("GetTaskActivityByID/{taskId}")]
        public List<TblTaskActivity> GetTaskActivityByID(int taskId)
        {
            return _taskRepository.GetTaskActivityByID(taskId);
        }
         
        [HttpPost("AddTaskActivity")]
        public void AddTaskActivity([FromBody] TblTaskActivity tblTaskActivity)
        {
            _taskRepository.AddTaskActivity(tblTaskActivity);
        }
         
        [HttpPut("UpdateTaskActivity")]
        public bool UpdateTaskActivity([FromBody] TblTaskActivity tblTaskActivity)
        {
            return _taskRepository.UpdateTaskActivity(tblTaskActivity);
        }

        [HttpDelete("DeleteTaskActivity/{taskId}")]
        public bool DeleteTaskActivity(int taskId)
        {
            return _taskRepository.DeleteTaskActivity(taskId);
        }
    }
}

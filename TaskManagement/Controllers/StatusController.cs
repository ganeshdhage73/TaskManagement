using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet("GetAllStatus")]
        public List<TblStatus> GetAllStatus()
        {
            return _statusRepository.GetAllStatus();
        }

        [HttpGet("GetStatusByID/{statusId}")]
        public List<TblStatus> GetStatusByID(int statusId)
        {
            return _statusRepository.GetStatusByID(statusId);
        }
         
        [HttpPost("AddStatus")]
        public void AddStatus([FromBody] TblStatus tblStatus)
        {
            _statusRepository.AddStatus(tblStatus);
        }
         
        [HttpPut("UpdateStatus")]
        public bool UpdateStatus([FromBody] TblStatus tblStatus)
        {
            return _statusRepository.UpdateStatus(tblStatus);
        }

        [HttpDelete("DeleteStatus/{statusId}")]
        public bool DeleteStatus(int statusId)
        {
            return _statusRepository.DeleteStatus(statusId);
        }
    }
}

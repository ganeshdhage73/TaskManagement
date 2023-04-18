using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityRepository _IPriorityRepository;
        public PriorityController(IPriorityRepository IPriorityRepository)
        {
            _IPriorityRepository = IPriorityRepository;
        }

        [HttpGet("GetAllPriority")]
        public List<TblPriority> GetAllPriority()
        {
            return _IPriorityRepository.GetAllPriority();
        }

        [HttpGet("GetPriorityByID/{priorityId}")]
        public List<TblPriority> GetPriorityByID(int priorityId)
        {
            return _IPriorityRepository.GetPriorityByID(priorityId);
        }
         
        [HttpPost("AddPriority")]
        public void AddPriority([FromBody] TblPriority tblPriority)
        {
            _IPriorityRepository.AddPriority(tblPriority);
        }
         
        [HttpPut("UpdatePriority")]
        public bool UpdatePriority([FromBody] TblPriority tblPriority)
        {
            return _IPriorityRepository.UpdatePriority(tblPriority);
        }

        [HttpDelete("DeletePriority/{priorityId}")]
        public bool DeletePriority(int priorityId)
        {
            return _IPriorityRepository.DeletePriority(priorityId);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interface;
using TaskManagement.Models; 

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        [HttpGet("GetAllUser")]
        public List<TblUser> GetAllUser()
        {
            return _UserRepository.GetAllUser();
        }

        [HttpGet("GetUserByID/{UserId}")]
        public List<TblUser> GetUserByID(int UserId)
        {
            return _UserRepository.GetUserByID(UserId);
        }
         
        [HttpPost("AddUser")]
        public void AddUser([FromBody] TblUser TblUser)
        {
            _UserRepository.AddUser(TblUser);
        }
         
        [HttpPut("UpdateUser")]
        public bool UpdateUser([FromBody] TblUser TblUser)
        {
            return _UserRepository.UpdateUser(TblUser);
        }

        [HttpDelete("DeleteUser/{UserId}")]
        public bool DeleteUser(int UserId)
        {
            return _UserRepository.DeleteUser(UserId);
        }
    }
}

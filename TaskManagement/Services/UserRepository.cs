using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class UserRepository : IUserRepository
    {
        private TaskManagementContext _taskManagementContext;
        public UserRepository(TaskManagementContext taskManagementContext)
        {
            _taskManagementContext = taskManagementContext;
        }

        public List<TblUser> AddUser(TblUser tblUser)
        {
            _taskManagementContext.TblUsers.Add(tblUser);
            _taskManagementContext.SaveChanges();

            List<TblUser> TblUserNew = _taskManagementContext.TblUsers.ToList();
            return TblUserNew;
        }

        public bool DeleteUser(int UserID)
        {
            TblUser TblUser = _taskManagementContext.TblUsers.Where(x => x.UserId == UserID).FirstOrDefault();
            if (TblUser == null)
            {
                return false;
            }
            _taskManagementContext.TblUsers.Remove(TblUser);
            _taskManagementContext.SaveChanges();
            return true;
        }

        public List<TblUser> GetAllUser()
        {
            return _taskManagementContext.TblUsers.ToList();
        }

        public List<TblUser> GetUserByID(int UserId)
        {
            return _taskManagementContext.TblUsers.Where(x => x.UserId == UserId).ToList();
        }

        public bool UpdateUser(TblUser tblUser)
        {
            var recordExist = _taskManagementContext.TblUsers.Where(x => x.UserId == tblUser.UserId).FirstOrDefault();
            if (recordExist != null)
            {
                recordExist.UserName = tblUser.UserName;
                _taskManagementContext.TblUsers.Add(recordExist);
                _taskManagementContext.Entry(recordExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _taskManagementContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

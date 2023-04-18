using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface IUserRepository
    {
        List<TblUser> GetAllUser();
        List<TblUser> GetUserByID(int TaskId);
        List<TblUser> AddUser(TblUser tblUser);
        bool UpdateUser(TblUser tblUser);
        bool DeleteUser(int TaskId);
    }
}

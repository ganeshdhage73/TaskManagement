using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface IPriorityRepository
    {
        List<TblPriority> GetAllPriority();
        List<TblPriority> GetPriorityByID(int PriorityId);
        List<TblPriority> AddPriority(TblPriority tblPriority);
        bool UpdatePriority(TblPriority tblPriority);
        bool DeletePriority(int PriorityId);
    }
}

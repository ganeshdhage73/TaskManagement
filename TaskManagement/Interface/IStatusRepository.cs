using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface IStatusRepository
    {
        List<TblStatus> GetAllStatus();
        List<TblStatus> GetStatusByID(int StatusId);
        List<TblStatus> AddStatus(TblStatus tblStatus);
        bool UpdateStatus(TblStatus tblStatus);
        bool DeleteStatus(int TaskId);
    }
}

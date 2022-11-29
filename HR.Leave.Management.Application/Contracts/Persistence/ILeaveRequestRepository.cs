using HR.Leave.Management.Domain;

namespace HR.Leave.Management.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();

        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    }
}
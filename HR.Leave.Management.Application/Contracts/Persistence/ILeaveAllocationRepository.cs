using HR.Leave.Management.Domain;

namespace HR.Leave.Management.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();

        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
    }
}
using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.Leave.Management.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HRLeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            var leaveAllocations = await _dbContext.LeaveAllocation.Include(x => x.LeaveType).ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation = await _dbContext.Set<LeaveAllocation>().Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.Id == id);
            return leaveAllocation;
        }
    }
}
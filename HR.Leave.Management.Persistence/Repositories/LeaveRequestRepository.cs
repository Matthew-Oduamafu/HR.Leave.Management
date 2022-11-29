using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.Leave.Management.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HRLeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dbContext.Set<LeaveRequest>().Include(x => x.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _dbContext.Set<LeaveRequest>().Include(x => x.LeaveType).FirstOrDefaultAsync(x => x.Id == id);
            return leaveRequest;
        }
    }
}
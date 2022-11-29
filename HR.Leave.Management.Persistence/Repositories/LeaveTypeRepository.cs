using HR.Leave.Management.Application.Contracts.Persistence;
using HR.Leave.Management.Domain;

namespace HR.Leave.Management.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HRLeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(HRLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
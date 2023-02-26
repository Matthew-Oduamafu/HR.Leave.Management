namespace HR.Leave.Management.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
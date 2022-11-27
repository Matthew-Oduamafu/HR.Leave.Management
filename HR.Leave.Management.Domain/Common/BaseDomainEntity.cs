namespace HR.Leave.Management.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? UpdatedBy { get; set;}
    }
}

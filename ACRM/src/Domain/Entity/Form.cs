namespace ACRM.src.Domain.Entity
{
    public class Form
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string? Experience { get; set; }
        public string Drugs { get; set; }
        public string Police { get; set; }
        public bool Housing { get; set; }
        public bool RelocationPayment { get; set; }
        public Guid LeadId { get; set; }
        public Lead Lead { get; set; }
        public Guid EmployerId { get; set; }
        public Employer Employer { get; set; }
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public DateTime TransferDate { get; set; }
    }
}

namespace ACRM.src.Domain.Entity
{
    public class Resource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employer> Employers { get; set; } = [];
        public List<Lead> Leads { get; set; } = [];
    }
}

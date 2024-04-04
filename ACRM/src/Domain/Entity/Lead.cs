namespace ACRM.src.Domain.Entity
{
    public class Lead
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Experience { get; set; }
        public string Moving { get; set; }
        public DateTime AppearanceDate { get; set; }
        public Guid EmployerId {  get; set; }
        public Employer? Employer { get; set; }
        public Guid FormId { get; set; }
        public Form? Form { get; set; }
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}

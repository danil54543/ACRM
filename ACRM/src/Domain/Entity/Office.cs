namespace ACRM.src.Domain.Entity
{
    public class Office
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Schedule { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionUkr { get; set; }
        public bool InSearch { get; set; }
        public int Prioriry { get; set; }
        public string AgeThreshold { get; set; }
        public List<Form> Forms { get; set; }
    }
}

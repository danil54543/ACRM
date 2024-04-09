using ACRM.src.Domain.Entity;

namespace ACRM.src.Domain.ViewModel.Admin.Branch
{
    public class GetBranchVM
    {
        public Guid Id { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageContentType { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionUkr { get; set; }
        public bool InSearch { get; set; }
        public int Prioriry { get; set; }
        public string AgeThreshold { get; set; }
        public string Gender { get; set; }
        public List<Form> Forms { get; set; }
    }
}

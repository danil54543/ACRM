namespace ACRM.src.Domain.ViewModel.Admin.Branch
{
    public class AddBranchVM
    {
        public IFormFile? ImageData { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionUkr { get; set; }
        public string Gender { get; set; }
        public string AgeThreshold { get; set; }
    }
}

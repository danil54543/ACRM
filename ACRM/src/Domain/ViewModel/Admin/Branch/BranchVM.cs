namespace ACRM.src.Domain.ViewModel.Admin.Branch
{
    public class BranchVM
    {
        public Guid Id { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageContentType { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool InSearch { get; set; }
        public int Prioriry { get; set; }

    }
}

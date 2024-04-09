using ACRM.src.Domain.Entity;
using ACRM.src.Domain.ViewModel.Admin.Branch;
using Microsoft.EntityFrameworkCore;
using static ACRM.src.BL.Repository.BranchRepository;

namespace ACRM.src.BL.Service
{
    public class BranchService(IBranchRepository branchRepository) : IBranchService
    {
        private readonly IBranchRepository _branchRepository = branchRepository;

        public async Task Create(AddBranchVM model)
        {
            try
            {
                var branch = new Office()
                {
                    Id = Guid.NewGuid(),
                    ImageData = model.ImageData,
                    ImageContentType = model.ImageContentType,
                    Name = model.Name,
                    Location = model.Location,
                    DescriptionRu = model.DescriptionRu,
                    DescriptionUkr = model.DescriptionUkr,
                    InSearch = true,
                    Prioriry = 1,
                    AgeThreshold = model.AgeThreshold,
                    Gender = model.Gender,
                    Forms = []
                };
                await _branchRepository.Create(branch);
            }
            catch
            {
            }
        }

        public async Task<GetBranchVM> Get(Guid branchId)
        {
            var branch = await _branchRepository.GetAll().FirstOrDefaultAsync(x => x.Id == branchId);
            var branchVM = new GetBranchVM()
            {
                Id = branch.Id,
                ImageData = branch.ImageData,
                ImageContentType = branch.ImageContentType,
                Name = branch.Name,
                Location = branch.Location,
                DescriptionRu = branch.DescriptionRu,
                DescriptionUkr = branch.DescriptionUkr,
                InSearch = true,
                Prioriry = 1,
                AgeThreshold = branch.AgeThreshold,
                Gender = branch.Gender,
                Forms = branch.Forms,
            };
            return branchVM;
        }

        public async Task<List<BranchVM>> GetAll()
        {
            try
            {
                var branches = await _branchRepository.GetAll().ToListAsync();
                var noteViewModels = from t in branches
                                     select new BranchVM()
                                     {
                                         Id = t.Id,
                                         Name = t.Name,
                                         Location = t.Location,
                                         InSearch = t.InSearch,
                                         Prioriry = t.Prioriry,
                                         ImageData = t.ImageData,
                                         ImageContentType = t.ImageContentType,
                                     };
                return noteViewModels.ToList();
            }
            catch
            {
                return [];
            }
        }

        public async Task Update(GetBranchVM model)
        {
            var branch = await _branchRepository.GetAll().FirstOrDefaultAsync(x => x.Id == model.Id);
            branch.ImageData = model.ImageData;
            branch.ImageContentType = model.ImageContentType;
            branch.Name = model.Name;
            branch.Location = model.Location;
            branch.DescriptionRu = model.DescriptionRu;
            branch.DescriptionUkr = model.DescriptionUkr;
            branch.InSearch = model.InSearch;
            branch.Prioriry = model.Prioriry;
            branch.AgeThreshold = model.AgeThreshold;
            branch.Gender = model.Gender;
            await _branchRepository.Update(branch);
        }
    }
    public interface IBranchService
    {
        Task Create(AddBranchVM model);
        Task Update(GetBranchVM model);
        Task<List<BranchVM>> GetAll();
        Task<GetBranchVM> Get(Guid branchId);
    }
}

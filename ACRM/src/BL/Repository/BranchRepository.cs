using ACRM.src.Data;
using ACRM.src.Domain.Entity;
using static ACRM.src.BL.Repository.BranchRepository;

namespace ACRM.src.BL.Repository
{
    public class BranchRepository(AppDbContext db): IBranchRepository
    {
        private readonly AppDbContext db = db;
        public IQueryable<Office> GetAll()
        {
            return db.Offices;
        }

        public async Task Delete(Office entity)
        {
            db.Offices.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task Create(Office entity)
        {
            await db.Offices.AddAsync(entity);
            await db.SaveChangesAsync();
        }


        public async Task<Office> Update(Office entity)
        {
            db.Offices.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
        public interface IBranchRepository
        {
            Task Create(Office entity);
            Task Delete(Office entity);
            Task<Office> Update(Office entity);
            IQueryable<Office> GetAll();
        }
    }
}

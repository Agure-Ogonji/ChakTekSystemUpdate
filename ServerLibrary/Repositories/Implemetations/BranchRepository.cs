using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
    public class BranchRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Branch>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDBContext.Branches.FindAsync(id);
            if (dep is null) return NotFound();

            appDBContext.Branches.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Branch>> GetAll() => await appDBContext.Branches.AsNoTracking().Include(d=>d.Department).ToListAsync();

        public async Task<Branch> GetById(int id) => await appDBContext.Branches.FindAsync(id);

        public async Task<GeneralResponse> Insert(Branch item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE DEPARTMENT IS ALREADY ADDED");
            appDBContext.Branches.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Branch item)
        {
            var branch = await appDBContext.Branches.FindAsync(item.Id);
            if (branch is null) return NotFound();

            branch.Name = item.Name;
            branch.DepartmentId = item.DepartmentId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "SORRY, THE DEPARTMENT IS NOT FOUND");
        private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETED");
        private async Task Commit() => await appDBContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDBContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}

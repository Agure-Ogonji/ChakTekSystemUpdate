using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
namespace ServerLibrary.Repositories.Implemetations
{
    public class DepartmentRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Department>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDBContext.Departments.FindAsync(id);
            if (dep is null) return NotFound();

            appDBContext.Departments.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Department>> GetAll() => await appDBContext.Departments.AsNoTracking().Include(gd => gd.GeneralDepartment).ToListAsync();

        public async Task<Department> GetById(int id) => await appDBContext.Departments.FindAsync(id);

        public async Task<GeneralResponse> Insert(Department item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE DEPARTMENT IS ALREADY ADDED");
            appDBContext.Departments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Department item)
        {
            var dep = await appDBContext.Departments.FindAsync(item.Id);
            if (dep is null) return NotFound();
            dep.Name = item.Name;
            dep.GeneralDepartmentId = item.GeneralDepartmentId;
            await Commit();
            return Success();
        }
        private async Task Commit() => await appDBContext.SaveChangesAsync();
        private static GeneralResponse NotFound() => new(false, "SORRY, THE DEPARTMENT IS NOT FOUND");
        private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETED");
        private async Task<bool> CheckName(string name)
        {
            var item = await appDBContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}

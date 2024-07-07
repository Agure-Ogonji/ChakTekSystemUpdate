using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
    public class GeneralDepartmentRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<GeneralDepartment>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDBContext.GeneralDepartments.FindAsync(id);
            if (dep is null) return NotFound();
            appDBContext.GeneralDepartments.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<GeneralDepartment>> GetAll() => await appDBContext.GeneralDepartments.ToListAsync();

        public async Task<GeneralDepartment> GetById(int id) => await appDBContext.GeneralDepartments.FindAsync(id);

        public async Task<GeneralResponse> Insert(GeneralDepartment item)
        {
            var checkIfNull = await CheckName(item.Name!);
            if (!checkIfNull) return new GeneralResponse(false, "THE GENERAL DEPARTMENT IS ALREADY ADDED");
            appDBContext.GeneralDepartments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(GeneralDepartment item)
        {
            var dep = await appDBContext.GeneralDepartments.FindAsync(item.Id);
            if(dep is null) return NotFound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }
        private static GeneralResponse NotFound() => new(false, "SORRY, THE DEPARTMENT IS NOT FOUND");
        private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETED");
        private async Task Commit() => await appDBContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDBContext.GeneralDepartments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}

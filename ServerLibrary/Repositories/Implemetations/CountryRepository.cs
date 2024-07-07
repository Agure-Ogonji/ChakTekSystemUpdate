using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
    public class CountryRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Country>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDBContext.Countries.FindAsync(id);
            if (dep is null) return NotFound();

            appDBContext.Countries.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll() => await appDBContext.Countries.ToListAsync();

        public async Task<Country> GetById(int id) => await appDBContext.Countries.FindAsync(id);

        public async Task<GeneralResponse> Insert(Country item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE DEPARTMENT IS ALREADY ADDED");
            appDBContext.Countries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var dep = await appDBContext.Countries.FindAsync(item.Id);
            if (dep is null) return NotFound();

            dep.Name = item.Name;
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

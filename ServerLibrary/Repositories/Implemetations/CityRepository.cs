using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
namespace ServerLibrary.Repositories.Implemetations
{
    public class CityRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<City>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDBContext.Cities.FindAsync(id);
            if (dep is null) return NotFound();

            appDBContext.Cities.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll() => await appDBContext.Cities.AsNoTracking().Include(c=>c.Country).ToListAsync();

        public async Task<City> GetById(int id) => await appDBContext.Cities.FindAsync(id);

        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE DEPARTMENT IS ALREADY ADDED");
            appDBContext.Cities.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var city = await appDBContext.Cities.FindAsync(item.Id);
            if (city is null) return NotFound();

			city.Name = item.Name;
            city.CountryId = item.CountryId;
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

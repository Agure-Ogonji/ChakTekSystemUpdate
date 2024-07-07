using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implemetations
{
    public class TownRepository(AppDBContext appDBContext) :IGenericRepositoryInterface<Town>
    {

        public async Task<GeneralResponse> DeleteById(int id)
        {
            var dep = await appDBContext.Towns.FindAsync(id);
            if (dep is null) return NotFound();

            appDBContext.Towns.Remove(dep);
            await Commit();
            return Success();
        }

        public async Task<List<Town>> GetAll() => await appDBContext.Towns.AsNoTracking().Include(c=>c.City).ToListAsync();

        public async Task<Town> GetById(int id) => await appDBContext.Towns.FindAsync(id);

        public async Task<GeneralResponse> Insert(Town item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, $"THE {item.Name} IS ALREADY ADDED");
            appDBContext.Towns.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Town item)
        {
            var town = await appDBContext.Towns.FindAsync(item.Id);
            if (town is null) return NotFound();

			town.Name = item.Name;
            town.CityId = item.CityId;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "SORRY, THE TOWN IS NOT FOUND");
        private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETED");
        private async Task Commit() => await appDBContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDBContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}

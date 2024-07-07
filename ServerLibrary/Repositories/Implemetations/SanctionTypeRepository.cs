using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
	public class SanctionTypeRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<SanctionType>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.SanctionTypes.FindAsync(id);
			if (item is null) return NotFound();

			appDBContext.SanctionTypes.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<SanctionType>> GetAll() => await appDBContext.SanctionTypes.AsNoTracking().ToListAsync();

		public async Task<SanctionType> GetById(int id) => await appDBContext.SanctionTypes.FindAsync(id);

		public async Task<GeneralResponse> Insert(SanctionType item)
		{
			if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE SANCTIONTYPE IS ALREADY ADDED");
			appDBContext.SanctionTypes.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(SanctionType item)
		{
			var obj = await appDBContext.Branches.FindAsync(item.Id);
			if (obj is null) return NotFound();
			obj.Name = item.Name;
			await Commit();
			return Success();
		}
		private async Task Commit() => await appDBContext.SaveChangesAsync();
		private static GeneralResponse NotFound() => new(false, "THE DATA IS NOT FOUND");
		private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETE");
		private async Task<bool> CheckName(string name)
		{
			var item = await appDBContext.OvertimeTypes.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
			return item is null;
		}
	}

}
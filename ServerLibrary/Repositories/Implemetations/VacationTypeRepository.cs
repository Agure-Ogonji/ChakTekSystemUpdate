using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
	public class VacationTypeRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<VacationType>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.VacationTypes.FindAsync(id);
			if (item is null) return NotFound();

			appDBContext.VacationTypes.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<VacationType>> GetAll() => await appDBContext.VacationTypes.AsNoTracking().ToListAsync();

		public async Task<VacationType> GetById(int id) => await appDBContext.VacationTypes.FindAsync(id);

		public async Task<GeneralResponse> Insert(VacationType item)
		{
			if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE VACATIONTYPE IS ALREADY ADDED");
			appDBContext.VacationTypes.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(VacationType item)
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
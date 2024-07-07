using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
	public class VacationRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Vacation>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
			if (item is null) return NotFound();

			appDBContext.Vacations.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<Vacation>> GetAll() => await appDBContext.Vacations.AsNoTracking().Include(t => t.VacationType).ToListAsync();

		public async Task<Vacation> GetById(int id) => await appDBContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

		public async Task<GeneralResponse> Insert(Vacation item)
		{
			appDBContext.Vacations.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(Vacation item)
		{
			var obj = await appDBContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
			if (obj is null) return NotFound();
			obj.StartDate = item.StartDate;
			obj.NumberOfDays = item.NumberOfDays;
			obj.VacationTypeId = item.VacationTypeId;
			await Commit();
			return Success();
		}
		private async Task Commit() => await appDBContext.SaveChangesAsync();
		private static GeneralResponse NotFound() => new(false, "THE DATA IS NOT FOUND");
		private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETE");
	}

}
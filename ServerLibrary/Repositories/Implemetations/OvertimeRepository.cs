using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
namespace ServerLibrary.Repositories.Implemetations
{
	public class OvertimeRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Overtime>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
			if (item is null) return NotFound();

			appDBContext.Overtimes.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<Overtime>> GetAll() => await appDBContext.Overtimes.AsNoTracking().Include(t => t.OvertimeType).ToListAsync();

		public async Task<Overtime> GetById(int id) => await appDBContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

		public async Task<GeneralResponse> Insert(Overtime item)
		{
			appDBContext.Overtimes.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(Overtime item)
		{
			var obj = await appDBContext.Overtimes.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
			if (obj is null) return NotFound();
			obj.StartDate = item.StartDate;
			obj.EndDate = item.EndDate;
			obj.OvertimeTypeId = item.OvertimeTypeId;
			await Commit();
			return Success();
		}
		private async Task Commit() => await appDBContext.SaveChangesAsync();
		private static GeneralResponse NotFound() => new(false, "THE DATA IS NOT FOUND");
		private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETE");
	}

}

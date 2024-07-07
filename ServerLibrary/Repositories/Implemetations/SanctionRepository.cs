using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
	public class SanctionRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Sanction>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.Sanctions.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
			if (item is null) return NotFound();

			appDBContext.Sanctions.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<Sanction>> GetAll() => await appDBContext.Sanctions.AsNoTracking().Include(t => t.SanctionType).ToListAsync();

		public async Task<Sanction> GetById(int id) => await appDBContext.Sanctions.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

		public async Task<GeneralResponse> Insert(Sanction item)
		{
			appDBContext.Sanctions.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(Sanction item)
		{
			var obj = await appDBContext.Sanctions.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
			if (obj is null) return NotFound();
			obj.PunishmentDate = item.PunishmentDate;
			obj.Punishment = item.Punishment;
			obj.Date = item.Date;
			obj.SanctionType = item.SanctionType;
			await Commit();
			return Success();
		}
		private async Task Commit() => await appDBContext.SaveChangesAsync();
		private static GeneralResponse NotFound() => new(false, "THE DATA IS NOT FOUND");
		private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETE");
	}

}
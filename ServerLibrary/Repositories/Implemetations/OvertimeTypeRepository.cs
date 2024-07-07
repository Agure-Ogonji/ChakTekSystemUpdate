using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
	public class OvertimeTypeRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<OvertimeType>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.OvertimeTypes.FindAsync(id);
			if (item is null) return NotFound();

			appDBContext.OvertimeTypes.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<OvertimeType>> GetAll() => await appDBContext.OvertimeTypes.AsNoTracking().ToListAsync();

		public async Task<OvertimeType> GetById(int id) => await appDBContext.OvertimeTypes.FindAsync(id);

		public async Task<GeneralResponse> Insert(OvertimeType item)
		{
			if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE OVERTIMETYPE IS ALREADY ADDED");
			appDBContext.OvertimeTypes.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(OvertimeType item)
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

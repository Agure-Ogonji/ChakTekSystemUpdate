using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
	public class DoctorRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Doctor>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.Doctors.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
			if (item is null) return NotFound();

			appDBContext.Doctors.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<Doctor>> GetAll() => await appDBContext.Doctors.AsNoTracking().ToListAsync();

		public async Task<Doctor> GetById(int id) => await appDBContext.Doctors.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

		public async Task<GeneralResponse> Insert(Doctor item)
		{
			appDBContext.Doctors.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(Doctor item)
		{
			var obj = await appDBContext.Doctors.FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
			if(obj is null) return NotFound();
			obj.MedicalRecommendation = item.MedicalRecommendation;
			obj.MedicalDiagnose = item.MedicalDiagnose;
			obj.Date = item.Date;
			await Commit();
			return Success();
		}
		private async Task Commit() => await appDBContext.SaveChangesAsync();
		private static GeneralResponse NotFound() => new(false, "THE DATA IS NOT FOUND");
		private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETE");
	}

}

using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implemetations
{
	public class EmployeeRepository(AppDBContext appDBContext) : IGenericRepositoryInterface<Employee>
	{
		public async Task<GeneralResponse> DeleteById(int id)
		{
			var item = await appDBContext.Employees.FindAsync(id);
			if (item is null) return NotFound();
			appDBContext.Employees.Remove(item);
			await Commit();
			return Success();
		}

		public async Task<List<Employee>> GetAll()
		{
			var employees = await appDBContext.Employees.AsNoTracking().Include(t => t.Town).ThenInclude(b => b.City).ThenInclude(c => c.Country).Include(b => b.Branch).ThenInclude(d => d.Department).ThenInclude(gd => gd.GeneralDepartment).ToListAsync();
			return employees;
		}

		public async Task<Employee> GetById(int id)
		{
			var employee = await appDBContext.Employees.Include(t => t.Town).ThenInclude(b => b.City).ThenInclude(c => c.Country).Include(b => b.Branch).ThenInclude(d => d.Department).ThenInclude(gd => gd.GeneralDepartment).FirstOrDefaultAsync(ei => ei.Id == id)!;
			return employee!;
		}

		public async Task<GeneralResponse> Insert(Employee item)
		{
			if (!await CheckName(item.Name!)) return new GeneralResponse(false, "THE EMPLOYEE IS ALREADY ADDED");
			appDBContext.Employees.Add(item);
			await Commit();
			return Success();
		}

		public async Task<GeneralResponse> Update(Employee employee)
		{
			var findUser = await appDBContext.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
			if (findUser is null) return new GeneralResponse(false, "THE EMPLOYEE DOES NOT EXIST");

			findUser.Name = employee.Name;
			findUser.Other = employee.Other;
			findUser.Address = employee.Address;
			findUser.TelephoneNumber = employee.TelephoneNumber;
			findUser.BranchId = employee.BranchId;
			findUser.TownId = employee.TownId;
			findUser.CivilId = employee.CivilId;
			findUser.FileNumber = employee.FileNumber;
			findUser.JobName = employee.JobName;
			findUser.Photo = employee.Photo;

			//appDBContext.Employees.Update(employee);
			await appDBContext.SaveChangesAsync();
			await Commit();
			return Success();
		}

		private async Task Commit() => await appDBContext.SaveChangesAsync();
		private static GeneralResponse NotFound() => new(false, "THE BRANCH IS NOT FOUND");
		private static GeneralResponse Success() => new(true, "THE PROCESS IS COMPLETED");
		private async Task<bool> CheckName(string name)
		{
			var item = await appDBContext.Employees.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
			return item is null ? true : false;
		}
	}
}

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTOs
{
	public class EmployeeGroup2
	{
		[Required]
		public string JobName { get; set; } = string.Empty;
		[Required, Range(1, 99999, ErrorMessage = "YOU MUST SELECT A BRANCH")]
		public int BranchId { get; set; }
		[Required, Range(1, 99999, ErrorMessage = "YOU MUST SELECT A TOWN")]
		public int TownId { get; set; }
		[Required]
		public string? Other { get; set; }
	}
}

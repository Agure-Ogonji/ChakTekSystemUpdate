using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Employee : BaseEntity
    {

        //public int Id { get; set; }

        //public string? Name { get; set; } = string.Empty;
        [Required]
        public string? CivilId { get; set; } = string.Empty;
        [Required]
        public string? FileNumber { get; set; } = string.Empty;
        //[Required]
        //public string? FullName { get; set; } = string.Empty;
        [Required]
        public string? JobName { get; set; } = string.Empty;
        [Required]
        public string? Address { get; set; } = string.Empty;
        [Required, DataType(DataType.PhoneNumber)]
        public string? TelephoneNumber { get; set; } = string.Empty;
        [Required]
        public string? Photo { get; set; } = string.Empty;
        public string? Other { get; set; }

        //RELATIONSHIP MANY TO ONE WITH BRANCH
        //public GeneralDepartment? GeneralDepartment { get; set; }
        //public int GeneralDepartmentId { get; set; }
        //public Department? Department { get; set; }
        //public int DepartmentId { get; set; }
        //[Required]
        //public string? Branch { get; set; } = string.Empty;
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }
        public Town? Town { get; set; }
        public int TownId { get; set; }
    }
}

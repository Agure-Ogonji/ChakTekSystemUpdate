using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; } = string.Empty;
        //[Required]
        //public string? Branch { get; set; } = string.Empty;

        //RELATIONSHIP IS ONE TO MANY
        //[JsonIgnore]
        //public List<Employee>? Employees { get; set; }
    }
}

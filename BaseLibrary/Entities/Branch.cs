using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity

    {

        //MANY TO ONE RELTIONSHIP WITH DEPARTMENT
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        //RELATIONSHIP ONE TO MANY WITH EMPLOYEE
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
    }
}

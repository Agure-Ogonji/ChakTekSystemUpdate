using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {

        //MANY TO ONE RELATIONSHIP WITH GENERAL DEPARTMENT
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }

        //ONE TO MANY RELATIONSHIP WITH BRANCH

        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}

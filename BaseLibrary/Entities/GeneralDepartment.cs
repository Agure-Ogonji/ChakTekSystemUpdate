
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //ONE TO MANY RELATIONSHIP TO DEPARTMENT

        [JsonIgnore]
        public List<Department>? Departments { get; set; }
    }
}

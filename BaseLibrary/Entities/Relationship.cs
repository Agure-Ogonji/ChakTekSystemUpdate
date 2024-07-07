using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Relationship
    {
        //RELATIONSHIP IS ONE TO MANY
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }

    }
}

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {
        //RELATIONSHIP ONE TO MANY WITH EMPLOYEE

        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
        //MANY TO ONE RELATIONSHIP WITH CITY
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}

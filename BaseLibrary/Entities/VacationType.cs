using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class VacationType : BaseEntity
    {
        //MANY TO ONE RELATIONSHIP WITH VACATION

        [JsonIgnore]
        public List<Vacation>? Vacations { get; set; }
    }
}

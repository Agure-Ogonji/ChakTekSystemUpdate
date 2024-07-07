using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity
    {
        //ONE TO MANE RELATIONSHIP WITH CITY

        [JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}

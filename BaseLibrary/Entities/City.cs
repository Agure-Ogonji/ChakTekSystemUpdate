using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        //MANY TO ONE RELATIONSHIP WITH COUNTRY
        public Country? Country { get; set; }
        public int CountryId { get; set; }

        //ONE TO MANY RELATIONSHIP TO TOWN

        [JsonIgnore]
        public List<Town>? Towns { get; set; }
    }
}

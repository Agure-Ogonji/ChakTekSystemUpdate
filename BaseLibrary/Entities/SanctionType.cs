using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class SanctionType : BaseEntity
    {
        //MANY TO ONE RELATIONSHIP WITH VACATION

        [JsonIgnore]
        public List<Sanction>? Sanctions { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class OvertimeType : BaseEntity
    {
        //MANY TO ONE RELATIONSHIP WITH OVERTIME

        [JsonIgnore]
        public List<Overtime>? Overtimes { get; set; }

    }
}

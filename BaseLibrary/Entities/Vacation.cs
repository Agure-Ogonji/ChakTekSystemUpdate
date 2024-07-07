using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Vacation : OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);

        //MANY TO ONE RELATIONSHIP WITH VACATION TYPE
        public VacationType? VacationType { get; set; }
        [Required]
        public int VacationTypeId { get; set; }

    }
}

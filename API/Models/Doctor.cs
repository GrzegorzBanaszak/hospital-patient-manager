using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [MaxLength(9)]
        [MinLength(9)]
        public string? PhoneNumber { get; set; }


        public ICollection<PatientVisit>? Patients { get; set; }

    }
}

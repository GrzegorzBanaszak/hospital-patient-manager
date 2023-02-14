using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }

        [MaxLength(11)]
        public string? Pesel { get; set; }

        [MaxLength(9)]
        [MinLength(9)]
        public string? PhoneNumber { get; set; }


        public ICollection<PatientVisit>? Visites { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class PatientVisit
    {
        [Key]
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string? Description { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [ForeignKey(nameof(Hospital))]

        public int HospitalId { get; set; }
        public Hospital? Hospital { get; set; }


    }
}

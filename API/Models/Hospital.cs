using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public ICollection<PatientVisit>? Patients { get; set; }

    }
}

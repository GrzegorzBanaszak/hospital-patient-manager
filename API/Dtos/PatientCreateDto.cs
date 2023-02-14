using API.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PatientCreateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }

        [MaxLength(11)]
        public string? Pesel { get; set; }

        [MaxLength(9)]
        [MinLength(9)]
        public string? PhoneNumber { get; set; }
    }
}

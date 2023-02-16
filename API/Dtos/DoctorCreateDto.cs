using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class DoctorCreateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [MaxLength(9)]
        [MinLength(9)]
        public string? PhoneNumber { get; set; }
    }
}
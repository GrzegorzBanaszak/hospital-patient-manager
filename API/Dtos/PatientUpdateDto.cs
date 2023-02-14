using API.Enums;


namespace API.Dtos
{
    public class PatientUpdateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }

        public string? Pesel { get; set; }

        public string? PhoneNumber { get; set; }
    }
}

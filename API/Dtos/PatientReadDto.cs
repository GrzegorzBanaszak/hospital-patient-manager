﻿using API.Enums;

namespace API.Dtos
{
    public class PatientReadDto
    {
      
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }

        public string? Pesel { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

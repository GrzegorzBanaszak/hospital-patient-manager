using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class PatientProfile: Profile
    {
        public PatientProfile()
        {
            // Source -> Target
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<Patient, PatientReadDto>();
            

        }
    }
}

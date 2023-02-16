using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{

    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorReadDto>();
            CreateMap<DoctorCreateDto, Doctor>();
        }
    }
}
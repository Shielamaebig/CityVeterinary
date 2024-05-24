using AutoMapper;
using CityVeterinary.Models;
using CityVeterinary.Dto;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace CityVeterinary.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Post
            CreateMap<CityVetEncoder, CityVetEncoderDto>().ReverseMap();
            CreateMap<Baranggay, BaranggayDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<PetType, PetTypeDto>().ReverseMap();
            CreateMap<PetOwner, PetOwnerDto>().ReverseMap();

        }
    }

}
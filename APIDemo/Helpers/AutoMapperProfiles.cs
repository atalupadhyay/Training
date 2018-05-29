using APIDemo.Dtos;
using APIDemo.Models;
using AutoMapper;

namespace APIDemo.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.FullLabel, opt =>
                    opt.MapFrom(src => src.ModelName.ToUpper() + " " + src.BrandName.ToString()))
                .ForMember(dest => dest.YearsOfService, opt =>
                    opt.MapFrom(src => src.YearOfConstruction.CalculateYearsOfService()));
        }
    }
}

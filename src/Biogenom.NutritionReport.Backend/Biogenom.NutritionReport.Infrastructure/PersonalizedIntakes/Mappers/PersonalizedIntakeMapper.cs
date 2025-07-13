using AutoMapper;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.Mappers;

public class PersonalizedIntakeMapper : Profile
{
    public PersonalizedIntakeMapper()
    {
        CreateMap<PersonalizedIntake, PersonalizedIntakeCreateUpdateDto>().ReverseMap();
        CreateMap<PersonalizedIntake, PersonalizedIntakeGetDto>().ReverseMap();
        CreateMap<PersonalizedIntake, PersonalizedIntakePatchDto>().ReverseMap();
    }
}
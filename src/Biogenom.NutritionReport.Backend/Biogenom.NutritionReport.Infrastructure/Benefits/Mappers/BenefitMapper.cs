using AutoMapper;
using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.Mappers;

public class BenefitMapper : Profile
{
    public BenefitMapper()
    {
        CreateMap<Benefit, BenefitCreateUpdateDto>().ReverseMap();
        CreateMap<Benefit, BenefitGetDto>().ReverseMap();
        CreateMap<Benefit, BenefitPatchDto>().ReverseMap();
    }
}
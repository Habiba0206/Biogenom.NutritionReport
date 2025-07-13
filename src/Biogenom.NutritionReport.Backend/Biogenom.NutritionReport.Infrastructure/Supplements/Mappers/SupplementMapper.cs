using AutoMapper;
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.Mappers;

public class SupplementMapper : Profile
{
    public SupplementMapper()
    {
        CreateMap<Supplement, SupplementCreateUpdateDto>().ReverseMap();
        CreateMap<Supplement, SupplementGetDto>().ReverseMap();
        CreateMap<Supplement, SupplementPatchDto>().ReverseMap();
    }
}
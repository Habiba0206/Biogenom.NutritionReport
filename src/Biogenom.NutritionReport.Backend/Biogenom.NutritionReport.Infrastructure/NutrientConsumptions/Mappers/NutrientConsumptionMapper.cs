using AutoMapper;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.Mappers;

public class NutrientConsumptionMapper : Profile
{
    public NutrientConsumptionMapper()
    {
        CreateMap<NutrientConsumption, NutrientConsumptionCreateUpdateDto>().ReverseMap();
        CreateMap<NutrientConsumption, NutrientConsumptionGetDto>().ReverseMap();
        CreateMap<NutrientConsumption, NutrientConsumptionPatchDto>().ReverseMap();
    }
}

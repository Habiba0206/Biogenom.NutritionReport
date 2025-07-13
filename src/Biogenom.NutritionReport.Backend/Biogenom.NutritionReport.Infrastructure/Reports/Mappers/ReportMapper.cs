using AutoMapper;
using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Entities;

namespace Biogenom.NutritionReport.Infrastructure.Reports.Mappers;

public class ReportMapper : Profile
{
    public ReportMapper()
    {
        CreateMap<Report, ReportCreateUpdateDto>().ReverseMap();
        CreateMap<Report, ReportGetDto>().ReverseMap();
        CreateMap<Report, ReportPatchDto>().ReverseMap();
    }
}

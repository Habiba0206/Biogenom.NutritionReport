using AutoMapper;
using Biogenom.NutritionReport.Application.Reports.Commands;
using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Application.Reports.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.Reports.CommandHandlers;

public class ReportPatchCommandHandler(
    IReportService service,
    IMapper mapper)
    : ICommandHandler<ReportPatchCommand, ReportPatchDto>
{
    public async Task<ReportPatchDto> Handle(ReportPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.ReportPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<ReportPatchDto>(entity);
    }
}
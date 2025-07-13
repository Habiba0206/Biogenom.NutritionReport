using AutoMapper;
using Biogenom.NutritionReport.Application.Reports.Commands;
using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Application.Reports.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Domain.Enums;
using Biogenom.NutritionReport.Infrastructure.Reports.Validators;
using FluentValidation;

namespace Biogenom.NutritionReport.Infrastructure.Reports.CommandHandlers;

public class ReportUpdateCommandHandler(
    IMapper mapper,
    IReportService service,
    ReportValidator validator) : ICommandHandler<ReportUpdateCommand, ReportCreateUpdateDto>
{
    public async Task<ReportCreateUpdateDto> Handle(ReportUpdateCommand request, CancellationToken cancellationToken)
    {
        var vr = await validator.ValidateAsync(
            request.ReportCreateUpdateDto,
            o => o.IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!vr.IsValid) throw new ValidationException(vr.Errors);

        var entity = mapper.Map<Report>(request.ReportCreateUpdateDto);
        var updated = await service.UpdateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<ReportCreateUpdateDto>(updated);
    }
}
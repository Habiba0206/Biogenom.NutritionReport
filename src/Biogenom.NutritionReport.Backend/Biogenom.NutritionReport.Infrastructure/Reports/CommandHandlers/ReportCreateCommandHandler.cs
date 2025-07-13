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

public class ReportCreateCommandHandler(
    IMapper mapper,
    IReportService service,
    ReportValidator validator) : ICommandHandler<ReportCreateCommand, ReportCreateUpdateDto>
{
    public async Task<ReportCreateUpdateDto> Handle(ReportCreateCommand request, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(
            request.ReportCreateUpdateDto,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var entity = mapper.Map<Report>(request.ReportCreateUpdateDto);
        var created = await service.CreateAsync(entity, cancellationToken: cancellationToken);
        return mapper.Map<ReportCreateUpdateDto>(created);
    }
}
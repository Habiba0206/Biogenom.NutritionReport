using AutoMapper;
using Biogenom.NutritionReport.Application.Benefits.Commands;
using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Application.Benefits.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.Benefits.CommandHandlers;

public class BenefitPatchCommandHandler(
    IBenefitService service,
    IMapper mapper)
    : ICommandHandler<BenefitPatchCommand, BenefitPatchDto>
{
    public async Task<BenefitPatchDto> Handle(BenefitPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.BenefitPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<BenefitPatchDto>(entity);
    }
}
using AutoMapper;
using Biogenom.NutritionReport.Application.Supplements.Commands;
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Application.Supplements.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.CommandHandlers;

public class SupplementPatchCommandHandler(
    ISupplementService service,
    IMapper mapper)
    : ICommandHandler<SupplementPatchCommand, SupplementPatchDto>
{
    public async Task<SupplementPatchDto> Handle(SupplementPatchCommand request, CancellationToken cancellationToken)
    {
        var entity = await service.PatchAsync(request.SupplementPatchDto, cancellationToken: cancellationToken);
        return mapper.Map<SupplementPatchDto>(entity);
    }
}
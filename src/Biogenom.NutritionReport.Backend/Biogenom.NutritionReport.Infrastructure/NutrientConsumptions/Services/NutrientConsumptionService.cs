using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Exceptions;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Persistence.Extensions;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Infrastructure.NutrientConsumptions.Services;

public class NutrientConsumptionService(INutrientConsumptionRepository repository) : INutrientConsumptionService
{
    public IQueryable<NutrientConsumption> Get(
        Expression<Func<NutrientConsumption, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<NutrientConsumption> Get(
        NutrientConsumptionFilter filter,
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions)
        .ApplyPagination(filter);

    public ValueTask<NutrientConsumption?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<NutrientConsumption>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<NutrientConsumption> CreateAsync(
        NutrientConsumption entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<NutrientConsumption> UpdateAsync(
        NutrientConsumption entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) 
            ?? throw new NotFoundException(nameof(NutrientConsumption), entity.Id);
        
        existing.Name = entity.Name;
        existing.CurrentValue = entity.CurrentValue;
        existing.Unit = entity.Unit;
        existing.RecommendedMin = entity.RecommendedMin;
        existing.RecommendedMax = entity.RecommendedMax;
        existing.IsDeficient = entity.IsDeficient;
        
        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<NutrientConsumption> PatchAsync(
        NutrientConsumptionPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken) 
            ?? throw new NotFoundException(nameof(NutrientConsumption), patchDto.Id);
        
        if (patchDto.Name is not null) existing.Name = patchDto.Name;
        if (patchDto.CurrentValue.HasValue) existing.CurrentValue = patchDto.CurrentValue.Value;
        if (patchDto.Unit is not null) existing.Unit = patchDto.Unit;
        if (patchDto.RecommendedMin.HasValue) existing.RecommendedMin = patchDto.RecommendedMin.Value;
        if (patchDto.RecommendedMax.HasValue) existing.RecommendedMax = patchDto.RecommendedMax.Value;
        if (patchDto.IsDeficient.HasValue) existing.IsDeficient = patchDto.IsDeficient.Value;
        
        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<NutrientConsumption?> DeleteAsync(
        NutrientConsumption entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<NutrientConsumption?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
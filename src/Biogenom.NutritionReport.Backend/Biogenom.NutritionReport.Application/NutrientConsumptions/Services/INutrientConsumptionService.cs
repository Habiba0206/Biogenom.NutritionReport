using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Application.NutrientConsumptions.Services;

public interface INutrientConsumptionService
{
    IQueryable<NutrientConsumption> Get(
        Expression<Func<NutrientConsumption, bool>>? predicate = default, 
        QueryOptions queryOptions = default);
    
    IQueryable<NutrientConsumption> Get(
        NutrientConsumptionFilter filter, 
        QueryOptions queryOptions = default);
    
    ValueTask<NutrientConsumption?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default);
    
    ValueTask<IList<NutrientConsumption>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<NutrientConsumption> CreateAsync(
        NutrientConsumption entity,
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<NutrientConsumption> UpdateAsync(
        NutrientConsumption entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<NutrientConsumption> PatchAsync(
        NutrientConsumptionPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<NutrientConsumption?> DeleteAsync(
        NutrientConsumption entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<NutrientConsumption?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
}
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Application.Supplements.Services;

public interface ISupplementService
{
    IQueryable<Supplement> Get(
        Expression<Func<Supplement, bool>>? predicate = default,
        QueryOptions queryOptions = default);
    
    IQueryable<Supplement> Get(
        SupplementFilter filter, 
        QueryOptions queryOptions = default);
    
    ValueTask<Supplement?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default);
    
    ValueTask<IList<Supplement>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Supplement> CreateAsync(
        Supplement entity,
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Supplement> UpdateAsync(
        Supplement entity, 
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
    
    ValueTask<Supplement> PatchAsync(
        SupplementPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Supplement?> DeleteAsync(
        Supplement entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Supplement?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
}
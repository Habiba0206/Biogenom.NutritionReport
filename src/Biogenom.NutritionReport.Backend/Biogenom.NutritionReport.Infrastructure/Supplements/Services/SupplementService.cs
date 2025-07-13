using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Application.Supplements.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Exceptions;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Persistence.Extensions;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Infrastructure.Supplements.Services;

public class SupplementService(ISupplementRepository repository) : ISupplementService
{
    public IQueryable<Supplement> Get(
        Expression<Func<Supplement, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<Supplement> Get(
        SupplementFilter filter, 
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions)
        .ApplyPagination(filter);

    public ValueTask<Supplement?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Supplement>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Supplement> CreateAsync(
        Supplement entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<Supplement> UpdateAsync(
        Supplement entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) 
            ?? throw new NotFoundException(nameof(Supplement), entity.Id);
        
        existing.Name = entity.Name;
        existing.ImageUrl = entity.ImageUrl;
        existing.Description = entity.Description;
        
        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<Supplement> PatchAsync(
        SupplementPatchDto patchDto,
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken) 
            ?? throw new NotFoundException(nameof(Supplement), patchDto.Id);
        
        if (patchDto.Name is not null) existing.Name = patchDto.Name;
        if (patchDto.ImageUrl is not null) existing.ImageUrl = patchDto.ImageUrl;
        if (patchDto.Description is not null) existing.Description = patchDto.Description;
        
        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<Supplement?> DeleteAsync(
        Supplement entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Supplement?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Exceptions;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Persistence.Extensions;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Infrastructure.PersonalizedIntakes.Services;

public class PersonalizedIntakeService(IPersonalizedIntakeRepository repository) : IPersonalizedIntakeService
{
    public IQueryable<PersonalizedIntake> Get(
        Expression<Func<PersonalizedIntake, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<PersonalizedIntake> Get(
        PersonalizedIntakeFilter filter, 
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions)
        .ApplyPagination(filter);

    public ValueTask<PersonalizedIntake?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<PersonalizedIntake>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<PersonalizedIntake> CreateAsync(
        PersonalizedIntake entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<PersonalizedIntake> UpdateAsync(
        PersonalizedIntake entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) 
            ?? throw new NotFoundException(nameof(PersonalizedIntake), entity.Id);
        
        existing.NutrientName = entity.NutrientName;
        existing.NewValue = entity.NewValue;
        existing.Unit = entity.Unit;
        existing.Source = entity.Source;
        
        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<PersonalizedIntake> PatchAsync(
        PersonalizedIntakePatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(patchDto.Id, cancellationToken: cancellationToken) 
            ?? throw new NotFoundException(nameof(PersonalizedIntake), patchDto.Id);
        
        if (patchDto.NutrientName is not null) existing.NutrientName = patchDto.NutrientName;
        if (patchDto.NewValue.HasValue) existing.NewValue = patchDto.NewValue.Value;
        if (patchDto.Unit is not null) existing.Unit = patchDto.Unit;
        if (patchDto.Source is not null) existing.Source = patchDto.Source;
        
        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<PersonalizedIntake?> DeleteAsync(
        PersonalizedIntake entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<PersonalizedIntake?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
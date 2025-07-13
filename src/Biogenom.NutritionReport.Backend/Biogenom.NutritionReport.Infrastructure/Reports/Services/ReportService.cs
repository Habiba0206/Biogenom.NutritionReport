using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Application.Reports.Services;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Exceptions;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using Biogenom.NutritionReport.Persistence.Extensions;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Infrastructure.Reports.Services;

public class ReportService(IReportRepository repository) : IReportService
{
    public IQueryable<Report> Get(
        Expression<Func<Report, bool>>? predicate = null, 
        QueryOptions queryOptions = default) =>
        repository.Get(predicate, queryOptions);

    public IQueryable<Report> Get(
        ReportFilter filter,
        QueryOptions queryOptions = default) =>
        repository.Get(queryOptions: queryOptions)
        .ApplyPagination(filter);

    public ValueTask<Report?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Report>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default) =>
        repository.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Report> CreateAsync(
        Report entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.CreateAsync(entity, commandOptions, cancellationToken);

    public async ValueTask<Report> UpdateAsync(
        Report entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(entity.Id) 
            ?? throw new NotFoundException(nameof(Report), entity.Id);

        return await repository.UpdateAsync(existing, commandOptions, cancellationToken);
    }

    public async ValueTask<Report> PatchAsync(
        ReportPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default)
    {
        var existing = await repository.GetByIdAsync(
            patchDto.Id, cancellationToken: cancellationToken) 
            ?? throw new NotFoundException(nameof(Report), patchDto.Id);

        return await repository.UpdateAsync(existing, cancellationToken: cancellationToken);
    }

    public ValueTask<Report?> DeleteAsync(
        Report entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default) =>
        repository.DeleteAsync(entity, commandOptions, cancellationToken);

    public ValueTask<Report?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
        repository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
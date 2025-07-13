using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Application.Reports.Services;

public interface IReportService
{
    IQueryable<Report> Get(
        Expression<Func<Report, bool>>? predicate = default, 
        QueryOptions queryOptions = default);
    
    IQueryable<Report> Get(
        ReportFilter filter, 
        QueryOptions queryOptions = default);
    
    ValueTask<Report?> GetByIdAsync(
        Guid id, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<bool> CheckByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default);
    
    ValueTask<IList<Report>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        QueryOptions queryOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Report> CreateAsync(
        Report entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Report> UpdateAsync(
        Report entity, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Report> PatchAsync(
        ReportPatchDto patchDto, 
        CommandOptions commandOptions = default, 
        CancellationToken cancellationToken = default);
    
    ValueTask<Report?> DeleteAsync(
        Report entity, 
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
    
    ValueTask<Report?> DeleteByIdAsync(
        Guid id, 
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
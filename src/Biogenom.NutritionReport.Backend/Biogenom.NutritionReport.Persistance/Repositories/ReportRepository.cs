using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Biogenom.NutritionReport.Persistence.Caching.Brokers;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;
using Biogenom.NutritionReport.Persistence.DataContexts;

namespace Biogenom.NutritionReport.Persistence.Repositories;

public class ReportRepository(AppDbContext db, ICacheBroker cacheBroker)
    : EntityRepositoryBase<Report, AppDbContext>(db, cacheBroker),
      IReportRepository
{
    public IQueryable<Report> Get(Expression<Func<Report, bool>>? predicate = null, QueryOptions queryOptions = default) =>
        base.Get(predicate, queryOptions)
            .Include(r => r.NutrientConsumptions)
            .Include(r => r.PersonalizedIntakes)
            .Include(r => r.Supplements)
            .Include(r => r.Benefits);

    public ValueTask<Report?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken ct = default) =>
        new (Get(r => r.Id == id, queryOptions)
       .FirstOrDefaultAsync(ct));

    public ValueTask<IList<Report>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken ct = default) =>
        base.GetByIdsAsync(ids, queryOptions, ct);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken ct = default) =>
        base.CheckByIdAsync(id, ct);

    public ValueTask<Report> CreateAsync(Report entity, CommandOptions cmd = default, CancellationToken ct = default) =>
        base.CreateAsync(entity, cmd, ct);

    public ValueTask<Report> UpdateAsync(Report entity, CommandOptions cmd, CancellationToken ct) =>
        base.UpdateAsync(entity, cmd, ct);

    public ValueTask<Report?> DeleteAsync(Report entity, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteAsync(entity, cmd, ct);

    public ValueTask<Report?> DeleteByIdAsync(Guid id, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteByIdAsync(id, cmd, ct);
}
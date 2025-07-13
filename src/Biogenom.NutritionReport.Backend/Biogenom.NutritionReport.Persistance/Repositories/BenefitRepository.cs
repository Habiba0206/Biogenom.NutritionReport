using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Biogenom.NutritionReport.Persistence.Caching.Brokers;
using Biogenom.NutritionReport.Persistence.DataContexts;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;

namespace Biogenom.NutritionReport.Persistence.Repositories;

public class BenefitRepository(AppDbContext db, ICacheBroker cacheBroker)
    : EntityRepositoryBase<Benefit, AppDbContext>(db, cacheBroker),
      IBenefitRepository
{
    public IQueryable<Benefit> Get(Expression<Func<Benefit, bool>>? predicate = null, QueryOptions queryOptions = default) =>
        base.Get(predicate, queryOptions)
            .Include(b => b.Report);

    public ValueTask<Benefit?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken ct = default) =>
        base.GetByIdAsync(id, queryOptions, ct);

    public ValueTask<IList<Benefit>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken ct = default) =>
        base.GetByIdsAsync(ids, queryOptions, ct);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken ct = default) =>
        base.CheckByIdAsync(id, ct);

    public ValueTask<Benefit> CreateAsync(Benefit entity, CommandOptions cmd = default, CancellationToken ct = default) =>
        base.CreateAsync(entity, cmd, ct);

    public ValueTask<Benefit> UpdateAsync(Benefit entity, CommandOptions cmd, CancellationToken ct) =>
        base.UpdateAsync(entity, cmd, ct);

    public ValueTask<Benefit?> DeleteAsync(Benefit entity, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteAsync(entity, cmd, ct);

    public ValueTask<Benefit?> DeleteByIdAsync(Guid id, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteByIdAsync(id, cmd, ct);
}
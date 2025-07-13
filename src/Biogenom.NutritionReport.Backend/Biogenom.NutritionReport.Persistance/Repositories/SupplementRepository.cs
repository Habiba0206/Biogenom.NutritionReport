using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Biogenom.NutritionReport.Persistence.Caching.Brokers;
using Biogenom.NutritionReport.Persistence.DataContexts;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;

namespace Biogenom.NutritionReport.Persistence.Repositories;

public class SupplementRepository(AppDbContext db, ICacheBroker cacheBroker)
    : EntityRepositoryBase<Supplement, AppDbContext>(db, cacheBroker),
      ISupplementRepository
{
    public IQueryable<Supplement> Get(Expression<Func<Supplement, bool>>? predicate = null, QueryOptions queryOptions = default) =>
        base.Get(predicate, queryOptions)
            .Include(s => s.Report);

    public ValueTask<Supplement?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken ct = default) =>
        new(Get(r => r.Id == id, queryOptions)
       .FirstOrDefaultAsync(ct));

    public ValueTask<IList<Supplement>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken ct = default) =>
        base.GetByIdsAsync(ids, queryOptions, ct);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken ct = default) =>
        base.CheckByIdAsync(id, ct);

    public ValueTask<Supplement> CreateAsync(Supplement entity, CommandOptions cmd = default, CancellationToken ct = default) =>
        base.CreateAsync(entity, cmd, ct);

    public ValueTask<Supplement> UpdateAsync(Supplement entity, CommandOptions cmd, CancellationToken ct) =>
        base.UpdateAsync(entity, cmd, ct);

    public ValueTask<Supplement?> DeleteAsync(Supplement entity, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteAsync(entity, cmd, ct);

    public ValueTask<Supplement?> DeleteByIdAsync(Guid id, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteByIdAsync(id, cmd, ct);
}
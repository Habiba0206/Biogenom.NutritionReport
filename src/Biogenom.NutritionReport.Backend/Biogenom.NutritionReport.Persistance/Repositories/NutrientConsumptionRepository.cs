using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Biogenom.NutritionReport.Persistence.Caching.Brokers;
using Biogenom.NutritionReport.Persistence.DataContexts;
using Biogenom.NutritionReport.Persistence.Repositories.Interfaces;

namespace Biogenom.NutritionReport.Persistence.Repositories;

public class NutrientConsumptionRepository(AppDbContext db, ICacheBroker cacheBroker)
    : EntityRepositoryBase<NutrientConsumption, AppDbContext>(db, cacheBroker),
      INutrientConsumptionRepository
{
    public IQueryable<NutrientConsumption> Get(Expression<Func<NutrientConsumption, bool>>? predicate = null, QueryOptions queryOptions = default) =>
        base.Get(predicate, queryOptions)
            .Include(n => n.Report);

    public ValueTask<NutrientConsumption?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken ct = default) =>
       new(Get(r => r.Id == id, queryOptions)
       .FirstOrDefaultAsync(ct));

    public ValueTask<IList<NutrientConsumption>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken ct = default) =>
        base.GetByIdsAsync(ids, queryOptions, ct);

    public ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken ct = default) =>
        base.CheckByIdAsync(id, ct);

    public ValueTask<NutrientConsumption> CreateAsync(NutrientConsumption entity, CommandOptions cmd = default, CancellationToken ct = default) =>
        base.CreateAsync(entity, cmd, ct);

    public ValueTask<NutrientConsumption> UpdateAsync(NutrientConsumption entity, CommandOptions cmd, CancellationToken ct) =>
        base.UpdateAsync(entity, cmd, ct);

    public ValueTask<NutrientConsumption?> DeleteAsync(NutrientConsumption entity, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteAsync(entity, cmd, ct);

    public ValueTask<NutrientConsumption?> DeleteByIdAsync(Guid id, CommandOptions cmd, CancellationToken ct = default) =>
        base.DeleteByIdAsync(id, cmd, ct);
}
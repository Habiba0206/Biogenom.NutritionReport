using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Persistence.Repositories.Interfaces;

public interface IBenefitRepository
{
    IQueryable<Benefit> Get(Expression<Func<Benefit, bool>>? predicate = default, QueryOptions queryOptions = default);

    ValueTask<Benefit?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<IList<Benefit>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken cancellationToken = default);

    ValueTask<Benefit> CreateAsync(Benefit entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    ValueTask<Benefit> UpdateAsync(Benefit entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    ValueTask<Benefit?> DeleteAsync(Benefit entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    ValueTask<Benefit?> DeleteByIdAsync(Guid id, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
}
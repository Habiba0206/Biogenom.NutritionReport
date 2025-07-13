using Biogenom.NutritionReport.Domain.Common.Commands;
using Biogenom.NutritionReport.Domain.Common.Queries;
using Biogenom.NutritionReport.Domain.Entities;
using System.Linq.Expressions;

namespace Biogenom.NutritionReport.Persistence.Repositories.Interfaces;

public interface IPersonalizedIntakeRepository
{
    IQueryable<PersonalizedIntake> Get(Expression<Func<PersonalizedIntake, bool>>? predicate = default, QueryOptions queryOptions = default);

    ValueTask<PersonalizedIntake?> GetByIdAsync(Guid id, QueryOptions queryOptions = default, CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<IList<PersonalizedIntake>> GetByIdsAsync(IEnumerable<Guid> ids, QueryOptions queryOptions = default, CancellationToken cancellationToken = default);

    ValueTask<PersonalizedIntake> CreateAsync(PersonalizedIntake entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    ValueTask<PersonalizedIntake> UpdateAsync(PersonalizedIntake entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    ValueTask<PersonalizedIntake?> DeleteAsync(PersonalizedIntake entity, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);

    ValueTask<PersonalizedIntake?> DeleteByIdAsync(Guid id, CommandOptions commandOptions = default, CancellationToken cancellationToken = default);
}
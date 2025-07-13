using MediatR;

namespace Biogenom.NutritionReport.Domain.Common.Queries;

/// <summary>
/// Represents a query in a CQRS (Command Query Responsibility Segregation) architecture.
/// </summary>
/// <typeparam name="TResult">The type of result returned by the query.</typeparam>
public interface IQuery<out TResult> : IRequest<TResult>, IQuery
{
}

/// <summary>
/// Defines interface for queries in a CQRS architecture.
/// </summary>
public interface IQuery
{
}

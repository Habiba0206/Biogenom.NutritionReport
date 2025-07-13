using MediatR;

namespace Biogenom.NutritionReport.Domain.Common.Queries;

/// <summary>
/// Represents a handler for processing queries in a CQRS (Command Query Responsibility Segregation) architecture.
/// </summary>
/// <typeparam name="TQuery">The type of query being handled.</typeparam>
/// <typeparam name="TResult">The type of result produced by handling the query.</typeparam>
public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
}

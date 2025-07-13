using MediatR;

namespace Biogenom.NutritionReport.Domain.Common.Commands;

/// <summary>
/// Represents a command in a CQRS (Command Query Responsibility Segregation) architecture.
/// </summary>
/// <typeparam name="TResult">The type of result produced by executing the command. </typeparam>
public interface ICommand<out TResult> : ICommand, IRequest<TResult>
{

}

/// <summary>
/// Defines interface for commands in a CQRS architecture.
/// </summary>
public interface ICommand
{
}

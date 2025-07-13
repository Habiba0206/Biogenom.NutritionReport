using MediatR;

namespace Biogenom.NutritionReport.Domain.Common.Commands;

/// <summary>
/// Represents a handler for a specific command type, responsible for processing the command and producing a result.
/// </summary>
/// <typeparam name="TCommand"> The type of command being handled. </typeparam>
/// <typeparam name="TResult"> The type of result producing by handling the command. </typeparam>
public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{

}

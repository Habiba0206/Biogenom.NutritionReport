using MassTransit;
using MediatR;

namespace Biogenom.NutritionReport.Domain.Common.Events;

/// <summary>
/// Represents base for event handlers
/// </summary>
/// <typeparam name="TEvent"></typeparam>
public abstract class EventHandlerBase<TEvent> : IEventHandler<TEvent> where TEvent : class, INotification
{
    public async Task Consume(ConsumeContext<TEvent> context) =>
    await HandleAsync(context.Message, context.CancellationToken);

    public async Task Handle(TEvent notification, CancellationToken cancellationToken) =>
    await HandleAsync(notification, cancellationToken);

    /// <summary>
    /// Internal handle method that can be called by any event bus.
    /// </summary>
    /// <param name="event">The event to handle.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    protected abstract ValueTask HandleAsync(TEvent @event, CancellationToken cancellationToken);
}

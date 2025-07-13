using MediatR;
using Biogenom.NutritionReport.Domain.Common.Events;
using Biogenom.NutritionReport.Application.Common.EventBus.Brokers;

namespace Biogenom.NutritionReport.Infrastructure.Common.EventBus.Brokers;

public class RabbitMqEventBusBroker(IPublisher publisher) : IEventBusBroker
{
    public async ValueTask PublishAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase =>
    await publisher.Publish(@event, cancellationToken);

    public async ValueTask PublishLocalAsync<TEvent>(
        TEvent @event,
        CancellationToken cancellationToken = default)
        where TEvent : EventBase =>
    await publisher.Publish(@event, cancellationToken);
}

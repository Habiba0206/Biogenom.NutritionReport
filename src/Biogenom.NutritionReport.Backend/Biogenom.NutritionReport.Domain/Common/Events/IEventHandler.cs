using MassTransit;
using MediatR;
using System.Collections.Concurrent;

namespace Biogenom.NutritionReport.Domain.Common.Events;

/// <summary>
/// Represents a handler for a specific type of event.
/// </summary>
/// <typeparam name="TEvent">The type of event being handled.</typeparam>
public interface IEventHandler<in TEvent> : IEventHandler,
    INotificationHandler<TEvent>,
    IConsumer<TEvent>
    where TEvent : class, INotification
{
}

/// <summary>
/// Defines an interface for event handlers
/// </summary>
public interface IEventHandler
{
}

using MediatR;

namespace Biogenom.NutritionReport.Domain.Common.Events;

/// <summary>
/// Represents an interface for events in a MediaTR-based system.
/// </summary>
public interface IEvent : INotification
{
    /// <summary>
    /// Gets or sets the unique identifier of the event.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the event was created.
    /// </summary>
    public DateTimeOffset CreatedTime { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating whether the evnet has been redelivered.
    /// </summary>
    public bool Redelivered { get; set; }
}

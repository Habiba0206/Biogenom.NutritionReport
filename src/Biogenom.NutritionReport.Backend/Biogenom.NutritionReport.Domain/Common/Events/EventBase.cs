namespace Biogenom.NutritionReport.Domain.Common.Events;

/// <summary>
/// Represents an implementation of `IEvent`, defining the properties for an event.
/// </summary>
public record EventBase : IEvent
{
    /// <summary>
    /// Gets or sets the unique identifier of the event.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the date and time when the event was created.
    /// </summary>
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets or sets a flag indicating whether the evnet has been redelivered.
    /// </summary>
    public bool Redelivered { get; set; }
}

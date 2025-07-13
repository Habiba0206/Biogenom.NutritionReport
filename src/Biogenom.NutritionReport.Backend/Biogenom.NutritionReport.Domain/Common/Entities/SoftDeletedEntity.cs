namespace Biogenom.NutritionReport.Domain.Common.Entities;

/// <summary>
/// Represnets an abstract class providing soft deletion functionality for entities
/// Inheriting properties `Entity` and implement `ISoftDeletedEntity`
/// </summary>
public abstract class SoftDeletedEntity : Entity, ISoftDeletedEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether the entity has been soft deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was soft deleted. This value will be <c>null</c> if the entity has not been soft deleted.
    /// </summary>
    public DateTimeOffset? DeletedTime { get; set; }
}

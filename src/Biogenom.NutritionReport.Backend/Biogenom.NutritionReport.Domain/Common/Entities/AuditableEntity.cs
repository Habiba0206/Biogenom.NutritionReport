namespace Biogenom.NutritionReport.Domain.Common.Entities;

/// <summary>
/// Represents an asbtract class providing audit functionalityfor entities.
/// Inheriting from `SoftDeletedEntity` and implementing `IAuditableEntity`
/// </summary>
public abstract class AuditableEntity : SoftDeletedEntity, IAuditableEntity
{
    /// <summary>
    /// Gets or sets the a=date and time when the entity was created.
    /// This value is typically set automatically by the system when the entity is first persisted
    /// </summary>
    public DateTimeOffset CreatedTime { get; set; }

    /// <summary>
    /// Gets or sets date and time when the entity was last updated.
    /// Can be null if the entity has never been modified.
    /// This value is updated automatically by the system whenever changes are made to the entity's properties.
    /// </summary>
    public DateTimeOffset? ModifiedTime { get; set; }
}

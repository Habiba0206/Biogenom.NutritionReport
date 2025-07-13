namespace Biogenom.NutritionReport.Domain.Common.Entities;

/// <summary>
/// Interface that marks an entity as being auditabe for deletion tracking.
/// </summary>
public interface IDeletionAudiableEntity
{
    /// <summary>
    /// Gets or sets the ID of user who deleted the entity.
    /// </summary>
    Guid DeletedByUserId { get; set; }
}


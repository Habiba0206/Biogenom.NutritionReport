namespace Biogenom.NutritionReport.Domain.Common.Entities;

/// <summary>
/// Interface that marks an entity as being auditabe for creation tracking.
/// </summary>
public interface ICreationAuditableEntity
{
    /// <summary>
    /// Gets or sets the ID of user who created the entity.
    /// </summary>
    Guid CreatedByUserId { get; set; }
}

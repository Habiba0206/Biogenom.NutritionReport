namespace Biogenom.NutritionReport.Domain.Common.Entities;

/// <summary>
/// Interface that marks an entity as being auditable for modification tracking.
/// </summary>
public interface IModificationAuditableEntity
{
    /// <summary>
    /// Gets or sets the ID of user who last modified the entity.
    /// </summary>
    Guid ModifiedByUserId { get; set; }
}

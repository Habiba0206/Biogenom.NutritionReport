namespace Biogenom.NutritionReport.Domain.Common.Entities;

/// <summary>
/// Represents a basic entity in the system with a unique identifier.
/// </summary>
public abstract class Entity : IEntity
{
    /// <summary>
    /// Gets or sets the uniue identifier of the entity. This identifier should be globally unique within the system.
    /// </summary>
    public Guid Id { get; set; }
}

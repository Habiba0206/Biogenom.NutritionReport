namespace Biogenom.NutritionReport.Domain.Common.Entities;

/// <summary>
/// Represents an interface for cloning object of type TClone.
/// </summary>
/// <typeparam name="TClone">The type of object to clone.</typeparam>
public interface IClonable<out TClone>
{
    /// <summary>
    /// Creates a clone of the object
    /// </summary>
    TClone Clone();
}

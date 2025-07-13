namespace Biogenom.NutritionReport.Domain.Common.Exceptions;

public class EntityExistsException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityExistsException"/> class.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <param name="key">The identifier of the entity.</param>
    public EntityExistsException(string entityName, string name)
        : base($"The entity '{entityName}' with name '{name}' exists.")
    {
    }
}
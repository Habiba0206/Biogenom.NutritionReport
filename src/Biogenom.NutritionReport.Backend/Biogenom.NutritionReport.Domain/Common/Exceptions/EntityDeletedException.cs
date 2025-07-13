namespace Biogenom.NutritionReport.Domain.Common.Exceptions;

public class EntityDeletedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityDeletedException"/> class.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <param name="key">The identifier of the entity.</param>
    public EntityDeletedException(string entityName, Guid key)
        : base($"The entity '{entityName}' with ID '{key}' has already been deleted.")
    {
    }
}

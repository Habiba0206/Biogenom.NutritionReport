namespace Biogenom.NutritionReport.Domain.Common.Exceptions;

public class NotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="entityName">The name of the entity.</param>
    /// <param name="key">The identifier of the entity.</param>
    public NotFoundException(string entityName, Guid key)
        : base($"'{entityName}' with ID '{key}' was not found.")
    {
    }
}

namespace Biogenom.NutritionReport.Domain.Common.Queries;

/// <summary>
/// Represents different query tracking modes that can used while querying
/// </summary>
public enum QueryTrackingMode
{
    /// <summary>
    /// Spceifies that queries should track changes to entities.
    /// </summary>
    AsTracking,

    /// <summary>
    /// Spceifies that queries should not track changes to entities.
    /// </summary>
    AsNoTracking,

    /// <summary>
    /// Spceifies that queries should not track changes to entities, but identity resolution is still performed.
    /// </summary>
    AsNoTrackingWithIdentityResolution
}

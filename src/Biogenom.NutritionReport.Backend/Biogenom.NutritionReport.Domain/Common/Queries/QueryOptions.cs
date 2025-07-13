namespace Biogenom.NutritionReport.Domain.Common.Queries;

/// <summary>
/// Represents a set of options to configure data querying behavior.
/// </summary>
public struct QueryOptions
{
    /// <summary>
    /// Gets or sets change tracking mode for query results.
    /// Using AsNoTracking change tracking mode can potentially improve the performance.
    /// </summary>
    public QueryTrackingMode QueryTrackingMode { get; set; }

    public QueryOptions(QueryTrackingMode queryTrackingMode) : this() => QueryTrackingMode = queryTrackingMode;
}

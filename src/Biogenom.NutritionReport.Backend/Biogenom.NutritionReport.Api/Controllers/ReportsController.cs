using Biogenom.NutritionReport.Api.Common;
using Biogenom.NutritionReport.Application.Reports.Commands;
using Biogenom.NutritionReport.Application.Reports.Models;
using Biogenom.NutritionReport.Application.Reports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.NutritionReport.Api.Controllers;

/// <summary>
/// Handles API operations related to nutrition reports.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ReportsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all reports with optional filters and pagination.
    /// </summary>
    /// <param name="query">Query parameters for filtering and pagination.</param>
    /// <param name="ct">Cancellation token to cancel the operation.</param>
    /// <returns>A list of reports or 204 No Content if none are found.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<ReportGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromQuery] ReportGetQuery query, CancellationToken ct = default)
    {
        var result = await mediator.Send(query, ct);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Retrieves a report by its unique identifier.
    /// </summary>
    /// <param name="reportId">The unique identifier of the report.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The requested report or 404 Not Found if not found.</returns>
    [HttpGet("{reportId:guid}")]
    [ProducesResponseType(typeof(ApiResponse<ReportGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid reportId, CancellationToken ct = default)
    {
        var result = await mediator.Send(new ReportGetByIdQuery { ReportId = reportId }, ct);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new nutrition report.
    /// </summary>
    /// <param name="command">The command containing report creation data.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The created report or 400 Bad Request if validation fails.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ReportCreateUpdateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] ReportCreateCommand command, CancellationToken ct = default)
    {
        var result = await mediator.Send(command, ct);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates an existing report.
    /// </summary>
    /// <param name="command">The command containing report update data.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The updated report object.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(ReportCreateUpdateDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] ReportUpdateCommand command, CancellationToken ct = default)
    {
        var result = await mediator.Send(command, ct);
        return Ok(result);
    }

    /// <summary>
    /// Partially updates an existing report.
    /// </summary>
    /// <param name="command">The patch command with updated fields.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The updated report with applied patch.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(ReportPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] ReportPatchCommand command, CancellationToken ct = default)
    {
        var result = await mediator.Send(command, ct);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a report by its ID.
    /// </summary>
    /// <param name="reportId">The ID of the report to delete.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Returns 200 OK if deletion was successful; otherwise 400 Bad Request.</returns>
    [HttpDelete("{reportId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid reportId, CancellationToken ct = default)
    {
        var result = await mediator.Send(new ReportDeleteByIdCommand { ReportId = reportId }, ct);
        return result ? Ok() : BadRequest();
    }

}
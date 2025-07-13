using Biogenom.NutritionReport.Api.Common;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Commands;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Models;
using Biogenom.NutritionReport.Application.NutrientConsumptions.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.NutritionReport.Api.Controllers;

/// <summary>
///     API endpoints for raw daily nutrient-consumption records
///     (actual intake compared to recommended norms).
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class NutrientConsumptionsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Retrieves a paginated list of nutrient-consumption rows.
    /// </summary>
    /// <param name="query">Filter and pagination parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    ///     <list type="bullet">
    ///         <item><description>200 – List of rows when data exists.</description></item>
    ///         <item><description>204 – No data found.</description></item>
    ///     </list>
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<NutrientConsumptionGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] NutrientConsumptionGetQuery query, CancellationToken cancellationToken = default)
    {
        var rows = await mediator.Send(query, cancellationToken);
        return rows.Any() ? Ok(rows) : NoContent();
    }

    /// <summary>
    ///     Retrieves a single nutrient-consumption record by ID.
    /// </summary>
    /// <param name="id">The unique identifier of the record.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    ///     200 with the record, or 404 if the ID does not exist.
    /// </returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<NutrientConsumptionGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var dto = await mediator.Send(new NutrientConsumptionGetByIdQuery { NutrientConsumptionId = id }, cancellationToken);
        return dto is not null ? Ok(dto) : NotFound();
    }

    /// <summary>
    ///     Creates a new nutrient-consumption record.
    /// </summary>
    /// <param name="command">Payload for the new record.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    ///     200 with the created entity, or 400 if validation fails.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(typeof(NutrientConsumptionCreateUpdateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] NutrientConsumptionCreateCommand command, CancellationToken cancellationToken = default)
    {
        var created = await mediator.Send(command, cancellationToken);
        return created is not null ? Ok(created) : BadRequest();
    }

    /// <summary>
    ///     Fully updates an existing nutrient-consumption record.
    /// </summary>
    /// <param name="command">Update command with full DTO.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated record.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(NutrientConsumptionCreateUpdateDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] NutrientConsumptionUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var updated = await mediator.Send(command, cancellationToken);
        return Ok(updated);
    }

    /// <summary>
    ///     Partially updates a nutrient-consumption record.
    /// </summary>
    /// <param name="command">Patch command containing partial changes.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The patched record.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(NutrientConsumptionPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] NutrientConsumptionPatchCommand command, CancellationToken cancellationToken = default)
    {
        var patched = await mediator.Send(command, cancellationToken);
        return Ok(patched);
    }

    /// <summary>
    ///     Deletes a nutrient-consumption record by ID.
    /// </summary>
    /// <param name="id">Record ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>200 if deleted; 400 if operation failed.</returns>
    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var ok = await mediator.Send(new NutrientConsumptionDeleteByIdCommand { NutrientConsumptionId = id }, cancellationToken);
        return ok ? Ok() : BadRequest();
    }
}

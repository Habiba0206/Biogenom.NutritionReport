using Biogenom.NutritionReport.Api.Common;
using Biogenom.NutritionReport.Application.Benefits.Commands;
using Biogenom.NutritionReport.Application.Benefits.Models;
using Biogenom.NutritionReport.Application.Benefits.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.NutritionReport.Api.Controllers;

/// <summary>
///     Provides CRUD operations for textual benefit statements associated
///     with the personalized nutrition plan.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BenefitsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Retrieves a list of benefit statements with optional filtering and pagination.
    /// </summary>
    /// <param name="query">Query object for filtering/pagination.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    ///     200 with list; 204 when no data.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<BenefitGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] BenefitGetQuery query, CancellationToken cancellationToken = default)
    {
        var list = await mediator.Send(query, cancellationToken);
        return list.Any() ? Ok(list) : NoContent();
    }

    /// <summary>
    ///     Retrieves a single benefit statement by its identifier.
    /// </summary>
    /// <param name="id">Benefit ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    ///     200 with the benefit, or 404 if not found.
    /// </returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<BenefitGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var dto = await mediator.Send(new BenefitGetByIdQuery { BenefitId = id }, cancellationToken);
        return dto is not null ? Ok(dto) : NotFound();
    }

    /// <summary>
    ///     Creates a new benefit statement.
    /// </summary>
    /// <param name="command">Create command payload.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    ///     200 with created entity; 400 on validation failure.
    /// </returns>
    [HttpPost]
    [ProducesResponseType(typeof(BenefitCreateUpdateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] BenefitCreateCommand command, CancellationToken cancellationToken = default)
    {
        var created = await mediator.Send(command, cancellationToken);
        return created is not null ? Ok(created) : BadRequest();
    }

    /// <summary>
    ///     Fully updates an existing benefit statement.
    /// </summary>
    /// <param name="command">Update command with full DTO.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The updated benefit.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(BenefitCreateUpdateDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] BenefitUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var updated = await mediator.Send(command, cancellationToken);
        return Ok(updated);
    }

    /// <summary>
    ///     Partially updates an existing benefit statement.
    /// </summary>
    /// <param name="command">Patch command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The patched benefit.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(BenefitPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] BenefitPatchCommand command, CancellationToken cancellationToken = default)
    {
        var patched = await mediator.Send(command, cancellationToken);
        return Ok(patched);
    }

    /// <summary>
    ///     Deletes a benefit statement by ID.
    /// </summary>
    /// <param name="id">Benefit ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>200 OK on success; 400 on failure.</returns>
    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var ok = await mediator.Send(new BenefitDeleteByIdCommand { BenefitId = id }, cancellationToken);
        return ok ? Ok() : BadRequest();
    }
}
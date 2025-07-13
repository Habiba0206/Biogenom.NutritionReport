using Biogenom.NutritionReport.Api.Common;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Commands;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Models;
using Biogenom.NutritionReport.Application.PersonalizedIntakes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.NutritionReport.Api.Controllers;

/// <summary>
/// Controller for managing Personalized Intakes.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PersonalizedIntakesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Retrieves all personalized intakes with optional filtering.
    /// </summary>
    /// <param name="query">Query parameters for personalized intake retrieval.</param>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns>List of personalized intakes or NoContent if none found.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<PersonalizedIntakeGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> GetAll([FromQuery] PersonalizedIntakeGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    /// Retrieves a personalized intake by ID.
    /// </summary>
    /// <param name="id">ID of the personalized intake to retrieve.</param>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns>The requested personalized intake if found; otherwise NotFound.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<PersonalizedIntakeGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new PersonalizedIntakeGetByIdQuery { PersonalizedIntakeId = id }, cancellationToken);
        return result is not null ? Ok(result) : NotFound();
    }

    /// <summary>
    /// Creates a new personalized intake.
    /// </summary>
    /// <param name="command">Command containing intake data to create.</param>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns>The created personalized intake.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(PersonalizedIntakeGetDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] PersonalizedIntakeCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return result is not null ? Ok(result) : BadRequest();
    }

    /// <summary>
    /// Updates an existing personalized intake.
    /// </summary>
    /// <param name="command">Command containing intake update data.</param>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns>The updated personalized intake.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(PersonalizedIntakeGetDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] PersonalizedIntakeUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Partially updates an existing personalized intake.
    /// </summary>
    /// <param name="command">Command containing patch data for personalized intake.</param>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns>The patched personalized intake.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(PersonalizedIntakePatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] PersonalizedIntakePatchCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Deletes a personalized intake by ID.
    /// </summary>
    /// <param name="id">ID of the intake to delete.</param>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns>OK if deleted; otherwise BadRequest.</returns>
    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new PersonalizedIntakeDeleteByIdCommand { PersonalizedIntakeId = id }, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}

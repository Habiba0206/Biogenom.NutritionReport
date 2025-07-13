using Biogenom.NutritionReport.Api.Common;
using Biogenom.NutritionReport.Application.Common.Services;
using Biogenom.NutritionReport.Application.Supplements.Commands;
using Biogenom.NutritionReport.Application.Supplements.Models;
using Biogenom.NutritionReport.Application.Supplements.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biogenom.NutritionReport.Api.Controllers;

/// <summary>
///     CRUD endpoints for supplement recommendations, including image upload.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class SupplementsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Retrieves a list of supplements with optional filtering and pagination.
    /// </summary>
    /// <param name="query">Filtering / pagination options.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>
    ///     200 with <see cref="ApiResponse{T}"/> when any data exists,
    ///     otherwise 204.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponse<List<SupplementGetDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async ValueTask<IActionResult> Get([FromQuery] SupplementGetQuery query, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(query, cancellationToken);
        return result.Any() ? Ok(result) : NoContent();
    }

    /// <summary>
    ///     Retrieves a specific supplement by its identifier.
    /// </summary>
    /// <param name="id">Supplement ID.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>200 with the supplement or 404 if not found.</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponse<SupplementGetDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var dto = await mediator.Send(new SupplementGetByIdQuery { SupplementId = id }, cancellationToken);
        return dto is not null ? Ok(dto) : NotFound();
    }

    /// <summary>
    ///     Creates a new supplement entry.
    /// </summary>
    /// <param name="command">Creation command containing payload.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>200 with created entity or 400 on validation failure.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(SupplementCreateUpdateDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> Create([FromBody] SupplementCreateCommand command, CancellationToken cancellationToken = default)
    {
        var created = await mediator.Send(command, cancellationToken);
        return created is not null ? Ok(created) : BadRequest();
    }

    /// <summary>
    ///     Fully updates an existing supplement.
    /// </summary>
    /// <param name="command">Update command with full DTO.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The updated supplement.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(SupplementCreateUpdateDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Update([FromBody] SupplementUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var updated = await mediator.Send(command, cancellationToken);
        return Ok(updated);
    }

    /// <summary>
    ///     Partially updates a supplement.
    /// </summary>
    /// <param name="command">Patch command with only changed fields.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>The patched supplement.</returns>
    [HttpPatch]
    [ProducesResponseType(typeof(SupplementPatchDto), StatusCodes.Status200OK)]
    public async ValueTask<IActionResult> Patch([FromBody] SupplementPatchCommand command, CancellationToken cancellationToken = default)
    {
        var patched = await mediator.Send(command, cancellationToken);
        return Ok(patched);
    }

    /// <summary>
    ///     Deletes a supplement by identifier.
    /// </summary>
    /// <param name="id">Supplement ID.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    /// <returns>200 if deleted, 400 otherwise.</returns>
    [HttpDelete("{id:guid}")]
    public async ValueTask<IActionResult> DeleteById([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var ok = await mediator.Send(new SupplementDeleteByIdCommand { SupplementId = id }, cancellationToken);
        return ok ? Ok() : BadRequest();
    }

    /// <summary>
    ///     Uploads a preview image for a supplement and returns the public URL.
    /// </summary>
    /// <param name="uploadService">File‑upload service resolved from DI.</param>
    /// <param name="dto">DTO containing the image file.</param>
    /// <returns>200 with the new image URL or 400 if no file provided.</returns>
    [HttpPost("upload-preview")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> UploadPreview(
        [FromServices] IFileUploadService uploadService,
        [FromForm] SupplementImageDto dto)
    {
        if (dto.File is null || dto.File.Length == 0)
            return BadRequest("No file uploaded.");

        var url = await uploadService.UploadImageAsync(dto.File);
        return Ok(new { url });
    }
}
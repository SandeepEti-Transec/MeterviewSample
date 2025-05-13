namespace MeterView.Identity.API.Controllers.v1;

using MeterView.Identity.API.Domain.UserOgranizations.Features;
using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/userogranizations")]
[ApiVersion("1.0")]
public sealed class UserOgranizationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new UserOgranization record.
    /// </summary>
    [HttpPost(Name = "AddUserOgranization")]
    public async Task<ActionResult<UserOgranizationDto>> AddUserOgranization([FromBody]UserOgranizationForCreationDto userOgranizationForCreation)
    {
        var command = new AddUserOgranization.Command(userOgranizationForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetUserOgranization",
            new { userOgranizationId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single UserOgranization by ID.
    /// </summary>
    [HttpGet("{userOgranizationId:guid}", Name = "GetUserOgranization")]
    public async Task<ActionResult<UserOgranizationDto>> GetUserOgranization(Guid userOgranizationId)
    {
        var query = new GetUserOgranization.Query(userOgranizationId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all UserOgranizations.
    /// </summary>
    [HttpGet(Name = "GetUserOgranizations")]
    public async Task<IActionResult> GetUserOgranizations([FromQuery] UserOgranizationParametersDto userOgranizationParametersDto)
    {
        var query = new GetUserOgranizationList.Query(userOgranizationParametersDto);
        var queryResponse = await mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Append("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Updates an entire existing UserOgranization.
    /// </summary>
    [HttpPut("{userOgranizationId:guid}", Name = "UpdateUserOgranization")]
    public async Task<IActionResult> UpdateUserOgranization(Guid userOgranizationId, UserOgranizationForUpdateDto userOgranization)
    {
        var command = new UpdateUserOgranization.Command(userOgranizationId, userOgranization);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing UserOgranization record.
    /// </summary>
    [HttpDelete("{userOgranizationId:guid}", Name = "DeleteUserOgranization")]
    public async Task<ActionResult> DeleteUserOgranization(Guid userOgranizationId)
    {
        var command = new DeleteUserOgranization.Command(userOgranizationId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

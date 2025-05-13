namespace MeterView.Identity.API.Controllers.v1;

using MeterView.Identity.API.Domain.UserRoles.Features;
using MeterView.Identity.API.Domain.UserRoles.Dtos;
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
[Route("api/v{v:apiVersion}/userroles")]
[ApiVersion("1.0")]
public sealed class UserRolesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new UserRole record.
    /// </summary>
    [HttpPost(Name = "AddUserRole")]
    public async Task<ActionResult<UserRoleDto>> AddUserRole([FromBody]UserRoleForCreationDto userRoleForCreation)
    {
        var command = new AddUserRole.Command(userRoleForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetUserRole",
            new { userRoleId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single UserRole by ID.
    /// </summary>
    [HttpGet("{userRoleId:guid}", Name = "GetUserRole")]
    public async Task<ActionResult<UserRoleDto>> GetUserRole(Guid userRoleId)
    {
        var query = new GetUserRole.Query(userRoleId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all UserRoles.
    /// </summary>
    [HttpGet(Name = "GetUserRoles")]
    public async Task<IActionResult> GetUserRoles([FromQuery] UserRoleParametersDto userRoleParametersDto)
    {
        var query = new GetUserRoleList.Query(userRoleParametersDto);
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
    /// Updates an entire existing UserRole.
    /// </summary>
    [HttpPut("{userRoleId:guid}", Name = "UpdateUserRole")]
    public async Task<IActionResult> UpdateUserRole(Guid userRoleId, UserRoleForUpdateDto userRole)
    {
        var command = new UpdateUserRole.Command(userRoleId, userRole);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing UserRole record.
    /// </summary>
    [HttpDelete("{userRoleId:guid}", Name = "DeleteUserRole")]
    public async Task<ActionResult> DeleteUserRole(Guid userRoleId)
    {
        var command = new DeleteUserRole.Command(userRoleId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

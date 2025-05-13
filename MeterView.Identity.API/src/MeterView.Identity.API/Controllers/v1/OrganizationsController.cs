namespace MeterView.Identity.API.Controllers.v1;

using MeterView.Identity.API.Domain.Organizations.Features;
using MeterView.Identity.API.Domain.Organizations.Dtos;
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
[Route("api/v{v:apiVersion}/organizations")]
[ApiVersion("1.0")]
public sealed class OrganizationsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Organization record.
    /// </summary>
    [HttpPost(Name = "AddOrganization")]
    public async Task<ActionResult<OrganizationDto>> AddOrganization([FromBody]OrganizationForCreationDto organizationForCreation)
    {
        var command = new AddOrganization.Command(organizationForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetOrganization",
            new { organizationId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Organization by ID.
    /// </summary>
    [HttpGet("{organizationId:guid}", Name = "GetOrganization")]
    public async Task<ActionResult<OrganizationDto>> GetOrganization(Guid organizationId)
    {
        var query = new GetOrganization.Query(organizationId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Organizations.
    /// </summary>
    [HttpGet(Name = "GetOrganizations")]
    public async Task<IActionResult> GetOrganizations([FromQuery] OrganizationParametersDto organizationParametersDto)
    {
        var query = new GetOrganizationList.Query(organizationParametersDto);
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
    /// Updates an entire existing Organization.
    /// </summary>
    [HttpPut("{organizationId:guid}", Name = "UpdateOrganization")]
    public async Task<IActionResult> UpdateOrganization(Guid organizationId, OrganizationForUpdateDto organization)
    {
        var command = new UpdateOrganization.Command(organizationId, organization);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Organization record.
    /// </summary>
    [HttpDelete("{organizationId:guid}", Name = "DeleteOrganization")]
    public async Task<ActionResult> DeleteOrganization(Guid organizationId)
    {
        var command = new DeleteOrganization.Command(organizationId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

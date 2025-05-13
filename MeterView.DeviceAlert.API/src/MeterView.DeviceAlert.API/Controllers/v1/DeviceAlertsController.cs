namespace MeterView.DeviceAlert.API.Controllers.v1;

using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/devicealerts")]
[ApiVersion("1.0")]
public sealed class DeviceAlertsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new DeviceAlert record.
    /// </summary>
    [HttpPost(Name = "AddDeviceAlert")]
    public async Task<ActionResult<DeviceAlertDto>> AddDeviceAlert([FromBody]DeviceAlertForCreationDto deviceAlertForCreation)
    {
        var command = new AddDeviceAlert.Command(deviceAlertForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetDeviceAlert",
            new { deviceAlertId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single DeviceAlert by ID.
    /// </summary>
    [HttpGet("{deviceAlertId:guid}", Name = "GetDeviceAlert")]
    public async Task<ActionResult<DeviceAlertDto>> GetDeviceAlert(Guid deviceAlertId)
    {
        var query = new GetDeviceAlert.Query(deviceAlertId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all DeviceAlerts.
    /// </summary>
    [HttpGet(Name = "GetDeviceAlerts")]
    public async Task<IActionResult> GetDeviceAlerts([FromQuery] DeviceAlertParametersDto deviceAlertParametersDto)
    {
        var query = new GetDeviceAlertList.Query(deviceAlertParametersDto);
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
    /// Updates an entire existing DeviceAlert.
    /// </summary>
    [HttpPut("{deviceAlertId:guid}", Name = "UpdateDeviceAlert")]
    public async Task<IActionResult> UpdateDeviceAlert(Guid deviceAlertId, DeviceAlertForUpdateDto deviceAlert)
    {
        var command = new UpdateDeviceAlert.Command(deviceAlertId, deviceAlert);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing DeviceAlert record.
    /// </summary>
    [HttpDelete("{deviceAlertId:guid}", Name = "DeleteDeviceAlert")]
    public async Task<ActionResult> DeleteDeviceAlert(Guid deviceAlertId)
    {
        var command = new DeleteDeviceAlert.Command(deviceAlertId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

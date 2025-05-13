namespace MeterView.Devices.API.Controllers.v1;

using MeterView.Devices.API.Domain.Devices.Features;
using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/devices")]
[ApiVersion("1.0")]
public sealed class DevicesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Device record.
    /// </summary>
    [HttpPost(Name = "AddDevice")]
    public async Task<ActionResult<DeviceDto>> AddDevice([FromBody]DeviceForCreationDto deviceForCreation)
    {
        var command = new AddDevice.Command(deviceForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetDevice",
            new { deviceId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Device by ID.
    /// </summary>
    [HttpGet("{deviceId:guid}", Name = "GetDevice")]
    public async Task<ActionResult<DeviceDto>> GetDevice(Guid deviceId)
    {
        var query = new GetDevice.Query(deviceId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Devices.
    /// </summary>
    [HttpGet(Name = "GetDevices")]
    public async Task<IActionResult> GetDevices([FromQuery] DeviceParametersDto deviceParametersDto)
    {
        var query = new GetDeviceList.Query(deviceParametersDto);
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
    /// Updates an entire existing Device.
    /// </summary>
    [HttpPut("{deviceId:guid}", Name = "UpdateDevice")]
    public async Task<IActionResult> UpdateDevice(Guid deviceId, DeviceForUpdateDto device)
    {
        var command = new UpdateDevice.Command(deviceId, device);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Device record.
    /// </summary>
    [HttpDelete("{deviceId:guid}", Name = "DeleteDevice")]
    public async Task<ActionResult> DeleteDevice(Guid deviceId)
    {
        var command = new DeleteDevice.Command(deviceId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

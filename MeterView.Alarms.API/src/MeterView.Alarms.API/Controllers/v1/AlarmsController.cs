namespace MeterView.Alarms.API.Controllers.v1;

using MeterView.Alarms.API.Domain.Alarms.Features;
using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/alarms")]
[ApiVersion("1.0")]
public sealed class AlarmsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Alarm record.
    /// </summary>
    [HttpPost(Name = "AddAlarm")]
    public async Task<ActionResult<AlarmDto>> AddAlarm([FromBody]AlarmForCreationDto alarmForCreation)
    {
        var command = new AddAlarm.Command(alarmForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetAlarm",
            new { alarmId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Alarm by ID.
    /// </summary>
    [HttpGet("{alarmId:guid}", Name = "GetAlarm")]
    public async Task<ActionResult<AlarmDto>> GetAlarm(Guid alarmId)
    {
        var query = new GetAlarm.Query(alarmId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Alarms.
    /// </summary>
    [HttpGet(Name = "GetAlarms")]
    public async Task<IActionResult> GetAlarms([FromQuery] AlarmParametersDto alarmParametersDto)
    {
        var query = new GetAlarmList.Query(alarmParametersDto);
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
    /// Updates an entire existing Alarm.
    /// </summary>
    [HttpPut("{alarmId:guid}", Name = "UpdateAlarm")]
    public async Task<IActionResult> UpdateAlarm(Guid alarmId, AlarmForUpdateDto alarm)
    {
        var command = new UpdateAlarm.Command(alarmId, alarm);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Alarm record.
    /// </summary>
    [HttpDelete("{alarmId:guid}", Name = "DeleteAlarm")]
    public async Task<ActionResult> DeleteAlarm(Guid alarmId)
    {
        var command = new DeleteAlarm.Command(alarmId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

namespace MeterView.Channels.API.Controllers.v1;

using MeterView.Channels.API.Domain.Channels.Features;
using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/channels")]
[ApiVersion("1.0")]
public sealed class ChannelsController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new Channel record.
    /// </summary>
    [HttpPost(Name = "AddChannel")]
    public async Task<ActionResult<ChannelDto>> AddChannel([FromBody]ChannelForCreationDto channelForCreation)
    {
        var command = new AddChannel.Command(channelForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetChannel",
            new { channelId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single Channel by ID.
    /// </summary>
    [HttpGet("{channelId:guid}", Name = "GetChannel")]
    public async Task<ActionResult<ChannelDto>> GetChannel(Guid channelId)
    {
        var query = new GetChannel.Query(channelId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all Channels.
    /// </summary>
    [HttpGet(Name = "GetChannels")]
    public async Task<IActionResult> GetChannels([FromQuery] ChannelParametersDto channelParametersDto)
    {
        var query = new GetChannelList.Query(channelParametersDto);
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
    /// Updates an entire existing Channel.
    /// </summary>
    [HttpPut("{channelId:guid}", Name = "UpdateChannel")]
    public async Task<IActionResult> UpdateChannel(Guid channelId, ChannelForUpdateDto channel)
    {
        var command = new UpdateChannel.Command(channelId, channel);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing Channel record.
    /// </summary>
    [HttpDelete("{channelId:guid}", Name = "DeleteChannel")]
    public async Task<ActionResult> DeleteChannel(Guid channelId)
    {
        var command = new DeleteChannel.Command(channelId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

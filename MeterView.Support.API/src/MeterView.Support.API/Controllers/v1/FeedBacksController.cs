namespace MeterView.Support.API.Controllers.v1;

using MeterView.Support.API.Domain.FeedBacks.Features;
using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/feedbacks")]
[ApiVersion("1.0")]
public sealed class FeedBacksController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new FeedBack record.
    /// </summary>
    [HttpPost(Name = "AddFeedBack")]
    public async Task<ActionResult<FeedBackDto>> AddFeedBack([FromBody]FeedBackForCreationDto feedBackForCreation)
    {
        var command = new AddFeedBack.Command(feedBackForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetFeedBack",
            new { feedBackId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single FeedBack by ID.
    /// </summary>
    [HttpGet("{feedBackId:guid}", Name = "GetFeedBack")]
    public async Task<ActionResult<FeedBackDto>> GetFeedBack(Guid feedBackId)
    {
        var query = new GetFeedBack.Query(feedBackId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all FeedBacks.
    /// </summary>
    [HttpGet(Name = "GetFeedBacks")]
    public async Task<IActionResult> GetFeedBacks([FromQuery] FeedBackParametersDto feedBackParametersDto)
    {
        var query = new GetFeedBackList.Query(feedBackParametersDto);
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
    /// Updates an entire existing FeedBack.
    /// </summary>
    [HttpPut("{feedBackId:guid}", Name = "UpdateFeedBack")]
    public async Task<IActionResult> UpdateFeedBack(Guid feedBackId, FeedBackForUpdateDto feedBack)
    {
        var command = new UpdateFeedBack.Command(feedBackId, feedBack);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing FeedBack record.
    /// </summary>
    [HttpDelete("{feedBackId:guid}", Name = "DeleteFeedBack")]
    public async Task<ActionResult> DeleteFeedBack(Guid feedBackId)
    {
        var command = new DeleteFeedBack.Command(feedBackId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

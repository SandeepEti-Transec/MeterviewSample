namespace MeterView.TrendLines.API.Controllers.v1;

using MeterView.TrendLines.API.Domain.TrendLines.Features;
using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/trendlines")]
[ApiVersion("1.0")]
public sealed class TrendLinesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Creates a new TrendLine record.
    /// </summary>
    [HttpPost(Name = "AddTrendLine")]
    public async Task<ActionResult<TrendLineDto>> AddTrendLine([FromBody]TrendLineForCreationDto trendLineForCreation)
    {
        var command = new AddTrendLine.Command(trendLineForCreation);
        var commandResponse = await mediator.Send(command);

        return CreatedAtRoute("GetTrendLine",
            new { trendLineId = commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single TrendLine by ID.
    /// </summary>
    [HttpGet("{trendLineId:guid}", Name = "GetTrendLine")]
    public async Task<ActionResult<TrendLineDto>> GetTrendLine(Guid trendLineId)
    {
        var query = new GetTrendLine.Query(trendLineId);
        var queryResponse = await mediator.Send(query);
        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all TrendLines.
    /// </summary>
    [HttpGet(Name = "GetTrendLines")]
    public async Task<IActionResult> GetTrendLines([FromQuery] TrendLineParametersDto trendLineParametersDto)
    {
        var query = new GetTrendLineList.Query(trendLineParametersDto);
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
    /// Updates an entire existing TrendLine.
    /// </summary>
    [HttpPut("{trendLineId:guid}", Name = "UpdateTrendLine")]
    public async Task<IActionResult> UpdateTrendLine(Guid trendLineId, TrendLineForUpdateDto trendLine)
    {
        var command = new UpdateTrendLine.Command(trendLineId, trendLine);
        await mediator.Send(command);
        return NoContent();
    }


    /// <summary>
    /// Deletes an existing TrendLine record.
    /// </summary>
    [HttpDelete("{trendLineId:guid}", Name = "DeleteTrendLine")]
    public async Task<ActionResult> DeleteTrendLine(Guid trendLineId)
    {
        var command = new DeleteTrendLine.Command(trendLineId);
        await mediator.Send(command);
        return NoContent();
    }

    // endpoint marker - do not delete this comment
}

namespace MeterView.Notification.API.Controllers.v1;

using MeterView.Notification.API.Domain.EmailTemplates.Features;
using MeterView.Notification.API.Domain.EmailTemplates.Dtos;
using MeterView.Notification.API.Resources;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using Asp.Versioning;
using MediatR;

[ApiController]
[Route("api/v{v:apiVersion}/emailtemplates")]
[ApiVersion("1.0")]
public sealed class EmailTemplatesController(IMediator mediator): ControllerBase
{    

    /// <summary>
    /// Gets a list of all EmailTemplates.
    /// </summary>
    [HttpGet(Name = "GetEmailTemplates")]
    public async Task<IActionResult> GetEmailTemplates([FromQuery] EmailTemplateParametersDto emailTemplateParametersDto)
    {
        var query = new GetEmailTemplateList.Query(emailTemplateParametersDto);
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

    // endpoint marker - do not delete this comment
}

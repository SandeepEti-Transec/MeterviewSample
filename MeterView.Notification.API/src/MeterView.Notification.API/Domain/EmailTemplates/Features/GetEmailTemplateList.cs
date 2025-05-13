namespace MeterView.Notification.API.Domain.EmailTemplates.Features;

using MeterView.Notification.API.Domain.EmailTemplates.Dtos;
using MeterView.Notification.API.Databases;
using MeterView.Notification.API.Exceptions;
using MeterView.Notification.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetEmailTemplateList
{
    public sealed record Query(EmailTemplateParametersDto QueryParameters) : IRequest<PagedList<EmailTemplateDto>>;

    public sealed class Handler(NotificationDbContext dbContext)
        : IRequestHandler<Query, PagedList<EmailTemplateDto>>
    {
        public async Task<PagedList<EmailTemplateDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.EmailTemplates.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToEmailTemplateDtoQueryable();

            return await PagedList<EmailTemplateDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}
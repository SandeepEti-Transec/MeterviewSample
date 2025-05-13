namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;

using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.Databases;
using MeterView.DeviceAlert.API.Exceptions;
using MeterView.DeviceAlert.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetDeviceAlertList
{
    public sealed record Query(DeviceAlertParametersDto QueryParameters) : IRequest<PagedList<DeviceAlertDto>>;

    public sealed class Handler(DeviceAlertDbContext dbContext)
        : IRequestHandler<Query, PagedList<DeviceAlertDto>>
    {
        public async Task<PagedList<DeviceAlertDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.DeviceAlerts.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToDeviceAlertDtoQueryable();

            return await PagedList<DeviceAlertDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}
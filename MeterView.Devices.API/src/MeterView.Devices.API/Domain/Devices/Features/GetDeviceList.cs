namespace MeterView.Devices.API.Domain.Devices.Features;

using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.Databases;
using MeterView.Devices.API.Exceptions;
using MeterView.Devices.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetDeviceList
{
    public sealed record Query(DeviceParametersDto QueryParameters) : IRequest<PagedList<DeviceDto>>;

    public sealed class Handler(DevicesDbContext dbContext)
        : IRequestHandler<Query, PagedList<DeviceDto>>
    {
        public async Task<PagedList<DeviceDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.Devices.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToDeviceDtoQueryable();

            return await PagedList<DeviceDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}
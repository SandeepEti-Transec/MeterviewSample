namespace MeterView.Channels.API.Domain.Channels.Features;

using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.Databases;
using MeterView.Channels.API.Exceptions;
using MeterView.Channels.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetChannelList
{
    public sealed record Query(ChannelParametersDto QueryParameters) : IRequest<PagedList<ChannelDto>>;

    public sealed class Handler(ChannelsDbContext dbContext)
        : IRequestHandler<Query, PagedList<ChannelDto>>
    {
        public async Task<PagedList<ChannelDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.Channels.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToChannelDtoQueryable();

            return await PagedList<ChannelDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}
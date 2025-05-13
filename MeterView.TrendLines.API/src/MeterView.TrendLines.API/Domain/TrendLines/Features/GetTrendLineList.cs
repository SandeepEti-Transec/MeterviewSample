namespace MeterView.TrendLines.API.Domain.TrendLines.Features;

using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.Databases;
using MeterView.TrendLines.API.Exceptions;
using MeterView.TrendLines.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetTrendLineList
{
    public sealed record Query(TrendLineParametersDto QueryParameters) : IRequest<PagedList<TrendLineDto>>;

    public sealed class Handler(TrendLinesDbContext dbContext)
        : IRequestHandler<Query, PagedList<TrendLineDto>>
    {
        public async Task<PagedList<TrendLineDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.TrendLines.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToTrendLineDtoQueryable();

            return await PagedList<TrendLineDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}
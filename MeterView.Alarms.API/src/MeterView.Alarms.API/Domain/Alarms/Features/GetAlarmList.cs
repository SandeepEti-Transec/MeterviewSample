namespace MeterView.Alarms.API.Domain.Alarms.Features;

using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.Databases;
using MeterView.Alarms.API.Exceptions;
using MeterView.Alarms.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetAlarmList
{
    public sealed record Query(AlarmParametersDto QueryParameters) : IRequest<PagedList<AlarmDto>>;

    public sealed class Handler(AlarmsDbContext dbContext)
        : IRequestHandler<Query, PagedList<AlarmDto>>
    {
        public async Task<PagedList<AlarmDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.Alarms.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToAlarmDtoQueryable();

            return await PagedList<AlarmDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}
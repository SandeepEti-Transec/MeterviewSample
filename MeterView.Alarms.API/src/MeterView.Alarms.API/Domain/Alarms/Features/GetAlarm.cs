namespace MeterView.Alarms.API.Domain.Alarms.Features;

using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.Databases;
using MeterView.Alarms.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetAlarm
{
    public sealed record Query(Guid AlarmId) : IRequest<AlarmDto>;

    public sealed class Handler(AlarmsDbContext dbContext)
        : IRequestHandler<Query, AlarmDto>
    {
        public async Task<AlarmDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Alarms
                .AsNoTracking()
                .GetById(request.AlarmId, cancellationToken);
            return result.ToAlarmDto();
        }
    }
}
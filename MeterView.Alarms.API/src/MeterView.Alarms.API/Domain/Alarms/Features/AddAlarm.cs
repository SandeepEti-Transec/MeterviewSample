namespace MeterView.Alarms.API.Domain.Alarms.Features;

using MeterView.Alarms.API.Databases;
using MeterView.Alarms.API.Domain.Alarms;
using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.Domain.Alarms.Models;
using MeterView.Alarms.API.Services;
using MeterView.Alarms.API.Exceptions;
using Mappings;
using MediatR;

public static class AddAlarm
{
    public sealed record Command(AlarmForCreationDto AlarmToAdd) : IRequest<AlarmDto>;

    public sealed class Handler(AlarmsDbContext dbContext)
        : IRequestHandler<Command, AlarmDto>
    {
        public async Task<AlarmDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var alarmToAdd = request.AlarmToAdd.ToAlarmForCreation();
            var alarm = Alarm.Create(alarmToAdd);

            await dbContext.Alarms.AddAsync(alarm, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return alarm.ToAlarmDto();
        }
    }
}
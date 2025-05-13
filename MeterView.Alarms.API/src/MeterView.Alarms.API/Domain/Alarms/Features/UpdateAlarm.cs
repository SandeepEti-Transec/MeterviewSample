namespace MeterView.Alarms.API.Domain.Alarms.Features;

using MeterView.Alarms.API.Domain.Alarms;
using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.Databases;
using MeterView.Alarms.API.Services;
using MeterView.Alarms.API.Domain.Alarms.Models;
using MeterView.Alarms.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateAlarm
{
    public sealed record Command(Guid AlarmId, AlarmForUpdateDto UpdatedAlarmData) : IRequest;

    public sealed class Handler(AlarmsDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var alarmToUpdate = await dbContext.Alarms.GetById(request.AlarmId, cancellationToken: cancellationToken);
            var alarmToAdd = request.UpdatedAlarmData.ToAlarmForUpdate();
            alarmToUpdate.Update(alarmToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
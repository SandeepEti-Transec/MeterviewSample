namespace MeterView.Alarms.API.Domain.Alarms.Mappings;

using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.Domain.Alarms.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class AlarmMapper
{
    public static partial AlarmForCreation ToAlarmForCreation(this AlarmForCreationDto alarmForCreationDto);
    public static partial AlarmForUpdate ToAlarmForUpdate(this AlarmForUpdateDto alarmForUpdateDto);
    public static partial AlarmDto ToAlarmDto(this Alarm alarm);
    public static partial IQueryable<AlarmDto> ToAlarmDtoQueryable(this IQueryable<Alarm> alarm);
}
namespace MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;

using AutoBogus;
using MeterView.Alarms.API.Domain.Alarms;
using MeterView.Alarms.API.Domain.Alarms.Dtos;

public sealed class FakeAlarmForUpdateDto : AutoFaker<AlarmForUpdateDto>
{
    public FakeAlarmForUpdateDto()
    {
    }
}
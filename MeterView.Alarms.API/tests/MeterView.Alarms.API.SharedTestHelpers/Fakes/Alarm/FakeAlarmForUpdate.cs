namespace MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;

using AutoBogus;
using MeterView.Alarms.API.Domain.Alarms;
using MeterView.Alarms.API.Domain.Alarms.Models;

public sealed class FakeAlarmForUpdate : AutoFaker<AlarmForUpdate>
{
    public FakeAlarmForUpdate()
    {
    }
}
namespace MeterView.Alarms.API.IntegrationTests.FeatureTests.Alarms;

using MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;
using MeterView.Alarms.API.Domain.Alarms.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class AlarmQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_alarm_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var alarmOne = new FakeAlarmBuilder().Build();
        await testingServiceScope.InsertAsync(alarmOne);

        // Act
        var query = new GetAlarm.Query(alarmOne.Id);
        var alarm = await testingServiceScope.SendAsync(query);

        // Assert
        alarm.Name.Should().Be(alarmOne.Name);
        alarm.Status.Should().Be(alarmOne.Status);
    }

    [Fact]
    public async Task get_alarm_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetAlarm.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}
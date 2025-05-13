namespace MeterView.Alarms.API.IntegrationTests.FeatureTests.Alarms;

using MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Alarms.API.Domain.Alarms.Features;

public class AddAlarmCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_alarm_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var alarmOne = new FakeAlarmForCreationDto().Generate();

        // Act
        var command = new AddAlarm.Command(alarmOne);
        var alarmReturned = await testingServiceScope.SendAsync(command);
        var alarmCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Alarms
            .FirstOrDefaultAsync(a => a.Id == alarmReturned.Id));

        // Assert
        alarmReturned.Name.Should().Be(alarmOne.Name);
        alarmReturned.Status.Should().Be(alarmOne.Status);

        alarmCreated.Name.Should().Be(alarmOne.Name);
        alarmCreated.Status.Should().Be(alarmOne.Status);
    }
}
namespace MeterView.Alarms.API.IntegrationTests.FeatureTests.Alarms;

using MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;
using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.Domain.Alarms.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateAlarmCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_alarm_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var alarm = new FakeAlarmBuilder().Build();
        await testingServiceScope.InsertAsync(alarm);
        var updatedAlarmDto = new FakeAlarmForUpdateDto().Generate();

        // Act
        var command = new UpdateAlarm.Command(alarm.Id, updatedAlarmDto);
        await testingServiceScope.SendAsync(command);
        var updatedAlarm = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Alarms
                .FirstOrDefaultAsync(a => a.Id == alarm.Id));

        // Assert
        updatedAlarm.Name.Should().Be(updatedAlarmDto.Name);
        updatedAlarm.Status.Should().Be(updatedAlarmDto.Status);
    }
}
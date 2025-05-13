namespace MeterView.Alarms.API.IntegrationTests.FeatureTests.Alarms;

using MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;
using MeterView.Alarms.API.Domain.Alarms.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteAlarmCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_alarm_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var alarm = new FakeAlarmBuilder().Build();
        await testingServiceScope.InsertAsync(alarm);

        // Act
        var command = new DeleteAlarm.Command(alarm.Id);
        await testingServiceScope.SendAsync(command);
        var alarmResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Alarms
                .CountAsync(a => a.Id == alarm.Id));

        // Assert
        alarmResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_alarm_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteAlarm.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_alarm_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var alarm = new FakeAlarmBuilder().Build();
        await testingServiceScope.InsertAsync(alarm);

        // Act
        var command = new DeleteAlarm.Command(alarm.Id);
        await testingServiceScope.SendAsync(command);
        var deletedAlarm = await testingServiceScope.ExecuteDbContextAsync(db => db.Alarms
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == alarm.Id));

        // Assert
        deletedAlarm?.IsDeleted.Should().BeTrue();
    }
}
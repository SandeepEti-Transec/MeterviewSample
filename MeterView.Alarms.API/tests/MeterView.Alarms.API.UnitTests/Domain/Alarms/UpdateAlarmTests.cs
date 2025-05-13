namespace MeterView.Alarms.API.UnitTests.Domain.Alarms;

using MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;
using MeterView.Alarms.API.Domain.Alarms;
using MeterView.Alarms.API.Domain.Alarms.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Alarms.API.Exceptions.ValidationException;

public class UpdateAlarmTests
{
    private readonly Faker _faker;

    public UpdateAlarmTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_alarm()
    {
        // Arrange
        var alarm = new FakeAlarmBuilder().Build();
        var updatedAlarm = new FakeAlarmForUpdate().Generate();
        
        // Act
        alarm.Update(updatedAlarm);

        // Assert
        alarm.Name.Should().Be(updatedAlarm.Name);
        alarm.Status.Should().Be(updatedAlarm.Status);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var alarm = new FakeAlarmBuilder().Build();
        var updatedAlarm = new FakeAlarmForUpdate().Generate();
        alarm.DomainEvents.Clear();
        
        // Act
        alarm.Update(updatedAlarm);

        // Assert
        alarm.DomainEvents.Count.Should().Be(1);
        alarm.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(AlarmUpdated));
    }
}
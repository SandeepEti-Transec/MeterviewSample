namespace MeterView.Alarms.API.UnitTests.Domain.Alarms;

using MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;
using MeterView.Alarms.API.Domain.Alarms;
using MeterView.Alarms.API.Domain.Alarms.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Alarms.API.Exceptions.ValidationException;

public class CreateAlarmTests
{
    private readonly Faker _faker;

    public CreateAlarmTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_alarm()
    {
        // Arrange
        var alarmToCreate = new FakeAlarmForCreation().Generate();
        
        // Act
        var alarm = Alarm.Create(alarmToCreate);

        // Assert
        alarm.Name.Should().Be(alarmToCreate.Name);
        alarm.Status.Should().Be(alarmToCreate.Status);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var alarmToCreate = new FakeAlarmForCreation().Generate();
        
        // Act
        var alarm = Alarm.Create(alarmToCreate);

        // Assert
        alarm.DomainEvents.Count.Should().Be(1);
        alarm.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(AlarmCreated));
    }
}
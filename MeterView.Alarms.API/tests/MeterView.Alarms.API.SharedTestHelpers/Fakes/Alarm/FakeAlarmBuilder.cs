namespace MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;

using MeterView.Alarms.API.Domain.Alarms;
using MeterView.Alarms.API.Domain.Alarms.Models;

public class FakeAlarmBuilder
{
    private AlarmForCreation _creationData = new FakeAlarmForCreation().Generate();

    public FakeAlarmBuilder WithModel(AlarmForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeAlarmBuilder WithName(string name)
    {
        _creationData.Name = name;
        return this;
    }
    
    public FakeAlarmBuilder WithStatus(string status)
    {
        _creationData.Status = status;
        return this;
    }
    
    public Alarm Build()
    {
        var result = Alarm.Create(_creationData);
        return result;
    }
}
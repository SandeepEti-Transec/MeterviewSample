namespace MeterView.Alarms.API.Domain.Alarms;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Alarms.API.Exceptions;
using MeterView.Alarms.API.Domain.Alarms.Models;
using MeterView.Alarms.API.Domain.Alarms.DomainEvents;


public class Alarm : BaseEntity
{
    public string Name { get; private set; }

    public string Status { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Alarm Create(AlarmForCreation alarmForCreation)
    {
        var newAlarm = new Alarm();

        newAlarm.Name = alarmForCreation.Name;
        newAlarm.Status = alarmForCreation.Status;

        newAlarm.QueueDomainEvent(new AlarmCreated(){ Alarm = newAlarm });
        
        return newAlarm;
    }

    public Alarm Update(AlarmForUpdate alarmForUpdate)
    {
        Name = alarmForUpdate.Name;
        Status = alarmForUpdate.Status;

        QueueDomainEvent(new AlarmUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Alarm() { } // For EF + Mocking
}
namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.DeviceAlert.API.Exceptions;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Models;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.DomainEvents;


public class DeviceAlert : BaseEntity
{
    public string Title { get; private set; }

    public bool Isactive { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static DeviceAlert Create(DeviceAlertForCreation deviceAlertForCreation)
    {
        var newDeviceAlert = new DeviceAlert();

        newDeviceAlert.Title = deviceAlertForCreation.Title;
        newDeviceAlert.Isactive = deviceAlertForCreation.Isactive;

        newDeviceAlert.QueueDomainEvent(new DeviceAlertCreated(){ DeviceAlert = newDeviceAlert });
        
        return newDeviceAlert;
    }

    public DeviceAlert Update(DeviceAlertForUpdate deviceAlertForUpdate)
    {
        Title = deviceAlertForUpdate.Title;
        Isactive = deviceAlertForUpdate.Isactive;

        QueueDomainEvent(new DeviceAlertUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected DeviceAlert() { } // For EF + Mocking
}
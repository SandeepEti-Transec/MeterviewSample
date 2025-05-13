namespace MeterView.Devices.API.Domain.Devices;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Devices.API.Exceptions;
using MeterView.Devices.API.Domain.Devices.Models;
using MeterView.Devices.API.Domain.Devices.DomainEvents;


public class Device : BaseEntity
{
    public string Name { get; private set; }

    public string LocationTag { get; private set; }

    public string Location { get; private set; }

    public string Status { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Device Create(DeviceForCreation deviceForCreation)
    {
        var newDevice = new Device();

        newDevice.Name = deviceForCreation.Name;
        newDevice.LocationTag = deviceForCreation.LocationTag;
        newDevice.Location = deviceForCreation.Location;
        newDevice.Status = deviceForCreation.Status;

        newDevice.QueueDomainEvent(new DeviceCreated(){ Device = newDevice });
        
        return newDevice;
    }

    public Device Update(DeviceForUpdate deviceForUpdate)
    {
        Name = deviceForUpdate.Name;
        LocationTag = deviceForUpdate.LocationTag;
        Location = deviceForUpdate.Location;
        Status = deviceForUpdate.Status;

        QueueDomainEvent(new DeviceUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Device() { } // For EF + Mocking
}
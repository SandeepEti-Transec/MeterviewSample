namespace MeterView.Devices.API.SharedTestHelpers.Fakes.Device;

using MeterView.Devices.API.Domain.Devices;
using MeterView.Devices.API.Domain.Devices.Models;

public class FakeDeviceBuilder
{
    private DeviceForCreation _creationData = new FakeDeviceForCreation().Generate();

    public FakeDeviceBuilder WithModel(DeviceForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeDeviceBuilder WithName(string name)
    {
        _creationData.Name = name;
        return this;
    }
    
    public FakeDeviceBuilder WithLocationTag(string locationTag)
    {
        _creationData.LocationTag = locationTag;
        return this;
    }
    
    public FakeDeviceBuilder WithLocation(string location)
    {
        _creationData.Location = location;
        return this;
    }
    
    public FakeDeviceBuilder WithStatus(string status)
    {
        _creationData.Status = status;
        return this;
    }
    
    public Device Build()
    {
        var result = Device.Create(_creationData);
        return result;
    }
}
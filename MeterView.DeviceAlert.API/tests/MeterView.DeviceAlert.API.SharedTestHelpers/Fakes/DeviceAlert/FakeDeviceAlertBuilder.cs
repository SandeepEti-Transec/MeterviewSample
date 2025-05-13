namespace MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;

using MeterView.DeviceAlert.API.Domain.DeviceAlerts;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Models;

public class FakeDeviceAlertBuilder
{
    private DeviceAlertForCreation _creationData = new FakeDeviceAlertForCreation().Generate();

    public FakeDeviceAlertBuilder WithModel(DeviceAlertForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeDeviceAlertBuilder WithTitle(string title)
    {
        _creationData.Title = title;
        return this;
    }
    
    public FakeDeviceAlertBuilder WithIsactive(bool isactive)
    {
        _creationData.Isactive = isactive;
        return this;
    }
    
    public DeviceAlert Build()
    {
        var result = DeviceAlert.Create(_creationData);
        return result;
    }
}
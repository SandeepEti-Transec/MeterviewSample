namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;

using MeterView.DeviceAlert.API.Databases;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Models;
using MeterView.DeviceAlert.API.Services;
using MeterView.DeviceAlert.API.Exceptions;
using Mappings;
using MediatR;

public static class AddDeviceAlert
{
    public sealed record Command(DeviceAlertForCreationDto DeviceAlertToAdd) : IRequest<DeviceAlertDto>;

    public sealed class Handler(DeviceAlertDbContext dbContext)
        : IRequestHandler<Command, DeviceAlertDto>
    {
        public async Task<DeviceAlertDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var deviceAlertToAdd = request.DeviceAlertToAdd.ToDeviceAlertForCreation();
            var deviceAlert = DeviceAlert.Create(deviceAlertToAdd);

            await dbContext.DeviceAlerts.AddAsync(deviceAlert, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return deviceAlert.ToDeviceAlertDto();
        }
    }
}
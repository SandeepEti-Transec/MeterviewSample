namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;

using MeterView.DeviceAlert.API.Domain.DeviceAlerts;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.Databases;
using MeterView.DeviceAlert.API.Services;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Models;
using MeterView.DeviceAlert.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateDeviceAlert
{
    public sealed record Command(Guid DeviceAlertId, DeviceAlertForUpdateDto UpdatedDeviceAlertData) : IRequest;

    public sealed class Handler(DeviceAlertDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var deviceAlertToUpdate = await dbContext.DeviceAlerts.GetById(request.DeviceAlertId, cancellationToken: cancellationToken);
            var deviceAlertToAdd = request.UpdatedDeviceAlertData.ToDeviceAlertForUpdate();
            deviceAlertToUpdate.Update(deviceAlertToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
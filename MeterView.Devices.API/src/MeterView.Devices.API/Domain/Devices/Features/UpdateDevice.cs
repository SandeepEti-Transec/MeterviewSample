namespace MeterView.Devices.API.Domain.Devices.Features;

using MeterView.Devices.API.Domain.Devices;
using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.Databases;
using MeterView.Devices.API.Services;
using MeterView.Devices.API.Domain.Devices.Models;
using MeterView.Devices.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateDevice
{
    public sealed record Command(Guid DeviceId, DeviceForUpdateDto UpdatedDeviceData) : IRequest;

    public sealed class Handler(DevicesDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var deviceToUpdate = await dbContext.Devices.GetById(request.DeviceId, cancellationToken: cancellationToken);
            var deviceToAdd = request.UpdatedDeviceData.ToDeviceForUpdate();
            deviceToUpdate.Update(deviceToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
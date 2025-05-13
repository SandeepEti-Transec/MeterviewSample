namespace MeterView.Devices.API.Domain.Devices.Features;

using MeterView.Devices.API.Databases;
using MeterView.Devices.API.Domain.Devices;
using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.Domain.Devices.Models;
using MeterView.Devices.API.Services;
using MeterView.Devices.API.Exceptions;
using Mappings;
using MediatR;

public static class AddDevice
{
    public sealed record Command(DeviceForCreationDto DeviceToAdd) : IRequest<DeviceDto>;

    public sealed class Handler(DevicesDbContext dbContext)
        : IRequestHandler<Command, DeviceDto>
    {
        public async Task<DeviceDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var deviceToAdd = request.DeviceToAdd.ToDeviceForCreation();
            var device = Device.Create(deviceToAdd);

            await dbContext.Devices.AddAsync(device, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return device.ToDeviceDto();
        }
    }
}
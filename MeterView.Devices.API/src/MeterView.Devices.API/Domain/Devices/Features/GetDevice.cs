namespace MeterView.Devices.API.Domain.Devices.Features;

using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.Databases;
using MeterView.Devices.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetDevice
{
    public sealed record Query(Guid DeviceId) : IRequest<DeviceDto>;

    public sealed class Handler(DevicesDbContext dbContext)
        : IRequestHandler<Query, DeviceDto>
    {
        public async Task<DeviceDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Devices
                .AsNoTracking()
                .GetById(request.DeviceId, cancellationToken);
            return result.ToDeviceDto();
        }
    }
}
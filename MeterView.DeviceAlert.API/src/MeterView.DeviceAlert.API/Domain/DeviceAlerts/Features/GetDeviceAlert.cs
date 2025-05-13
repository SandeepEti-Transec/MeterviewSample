namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;

using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.Databases;
using MeterView.DeviceAlert.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetDeviceAlert
{
    public sealed record Query(Guid DeviceAlertId) : IRequest<DeviceAlertDto>;

    public sealed class Handler(DeviceAlertDbContext dbContext)
        : IRequestHandler<Query, DeviceAlertDto>
    {
        public async Task<DeviceAlertDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.DeviceAlerts
                .AsNoTracking()
                .GetById(request.DeviceAlertId, cancellationToken);
            return result.ToDeviceAlertDto();
        }
    }
}
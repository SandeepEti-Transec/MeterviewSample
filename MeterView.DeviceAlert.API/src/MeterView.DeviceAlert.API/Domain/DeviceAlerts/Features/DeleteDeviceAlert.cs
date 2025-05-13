namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;

using MeterView.DeviceAlert.API.Databases;
using MeterView.DeviceAlert.API.Services;
using MeterView.DeviceAlert.API.Exceptions;
using MediatR;

public static class DeleteDeviceAlert
{
    public sealed record Command(Guid DeviceAlertId) : IRequest;

    public sealed class Handler(DeviceAlertDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.DeviceAlerts
                .GetById(request.DeviceAlertId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
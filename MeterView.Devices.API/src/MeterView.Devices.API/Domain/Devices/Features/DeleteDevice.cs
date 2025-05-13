namespace MeterView.Devices.API.Domain.Devices.Features;

using MeterView.Devices.API.Databases;
using MeterView.Devices.API.Services;
using MeterView.Devices.API.Exceptions;
using MediatR;

public static class DeleteDevice
{
    public sealed record Command(Guid DeviceId) : IRequest;

    public sealed class Handler(DevicesDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.Devices
                .GetById(request.DeviceId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
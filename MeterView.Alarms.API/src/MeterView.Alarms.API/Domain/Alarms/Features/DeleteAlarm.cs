namespace MeterView.Alarms.API.Domain.Alarms.Features;

using MeterView.Alarms.API.Databases;
using MeterView.Alarms.API.Services;
using MeterView.Alarms.API.Exceptions;
using MediatR;

public static class DeleteAlarm
{
    public sealed record Command(Guid AlarmId) : IRequest;

    public sealed class Handler(AlarmsDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.Alarms
                .GetById(request.AlarmId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
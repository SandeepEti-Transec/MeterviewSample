namespace MeterView.Channels.API.Domain.Channels.Features;

using MeterView.Channels.API.Databases;
using MeterView.Channels.API.Services;
using MeterView.Channels.API.Exceptions;
using MediatR;

public static class DeleteChannel
{
    public sealed record Command(Guid ChannelId) : IRequest;

    public sealed class Handler(ChannelsDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.Channels
                .GetById(request.ChannelId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
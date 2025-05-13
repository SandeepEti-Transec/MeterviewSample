namespace MeterView.Channels.API.Domain.Channels.Features;

using MeterView.Channels.API.Domain.Channels;
using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.Databases;
using MeterView.Channels.API.Services;
using MeterView.Channels.API.Domain.Channels.Models;
using MeterView.Channels.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateChannel
{
    public sealed record Command(Guid ChannelId, ChannelForUpdateDto UpdatedChannelData) : IRequest;

    public sealed class Handler(ChannelsDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var channelToUpdate = await dbContext.Channels.GetById(request.ChannelId, cancellationToken: cancellationToken);
            var channelToAdd = request.UpdatedChannelData.ToChannelForUpdate();
            channelToUpdate.Update(channelToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
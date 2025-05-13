namespace MeterView.Channels.API.Domain.Channels.Features;

using MeterView.Channels.API.Databases;
using MeterView.Channels.API.Domain.Channels;
using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.Domain.Channels.Models;
using MeterView.Channels.API.Services;
using MeterView.Channels.API.Exceptions;
using Mappings;
using MediatR;

public static class AddChannel
{
    public sealed record Command(ChannelForCreationDto ChannelToAdd) : IRequest<ChannelDto>;

    public sealed class Handler(ChannelsDbContext dbContext)
        : IRequestHandler<Command, ChannelDto>
    {
        public async Task<ChannelDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var channelToAdd = request.ChannelToAdd.ToChannelForCreation();
            var channel = Channel.Create(channelToAdd);

            await dbContext.Channels.AddAsync(channel, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return channel.ToChannelDto();
        }
    }
}
namespace MeterView.Channels.API.Domain.Channels.Features;

using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.Databases;
using MeterView.Channels.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetChannel
{
    public sealed record Query(Guid ChannelId) : IRequest<ChannelDto>;

    public sealed class Handler(ChannelsDbContext dbContext)
        : IRequestHandler<Query, ChannelDto>
    {
        public async Task<ChannelDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Channels
                .AsNoTracking()
                .GetById(request.ChannelId, cancellationToken);
            return result.ToChannelDto();
        }
    }
}
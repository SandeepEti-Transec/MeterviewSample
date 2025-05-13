namespace MeterView.Channels.API.Domain.Channels.Mappings;

using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.Domain.Channels.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class ChannelMapper
{
    public static partial ChannelForCreation ToChannelForCreation(this ChannelForCreationDto channelForCreationDto);
    public static partial ChannelForUpdate ToChannelForUpdate(this ChannelForUpdateDto channelForUpdateDto);
    public static partial ChannelDto ToChannelDto(this Channel channel);
    public static partial IQueryable<ChannelDto> ToChannelDtoQueryable(this IQueryable<Channel> channel);
}
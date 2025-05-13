namespace MeterView.Channels.API.Domain.Channels;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Channels.API.Exceptions;
using MeterView.Channels.API.Domain.Channels.Models;
using MeterView.Channels.API.Domain.Channels.DomainEvents;


public class Channel : BaseEntity
{
    public string Name { get; private set; }

    public string Value { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Channel Create(ChannelForCreation channelForCreation)
    {
        var newChannel = new Channel();

        newChannel.Name = channelForCreation.Name;
        newChannel.Value = channelForCreation.Value;

        newChannel.QueueDomainEvent(new ChannelCreated(){ Channel = newChannel });
        
        return newChannel;
    }

    public Channel Update(ChannelForUpdate channelForUpdate)
    {
        Name = channelForUpdate.Name;
        Value = channelForUpdate.Value;

        QueueDomainEvent(new ChannelUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Channel() { } // For EF + Mocking
}
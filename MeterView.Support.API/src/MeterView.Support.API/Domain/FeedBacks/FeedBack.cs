namespace MeterView.Support.API.Domain.FeedBacks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Support.API.Exceptions;
using MeterView.Support.API.Domain.FeedBacks.Models;
using MeterView.Support.API.Domain.FeedBacks.DomainEvents;


public class FeedBack : BaseEntity
{
    public string FullName { get; private set; }

    public string Title { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public string FeedBackOnMV { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static FeedBack Create(FeedBackForCreation feedBackForCreation)
    {
        var newFeedBack = new FeedBack();

        newFeedBack.FullName = feedBackForCreation.FullName;
        newFeedBack.Title = feedBackForCreation.Title;
        newFeedBack.Email = feedBackForCreation.Email;
        newFeedBack.PhoneNumber = feedBackForCreation.PhoneNumber;
        newFeedBack.FeedBackOnMV = feedBackForCreation.FeedBackOnMV;

        newFeedBack.QueueDomainEvent(new FeedBackCreated(){ FeedBack = newFeedBack });
        
        return newFeedBack;
    }

    public FeedBack Update(FeedBackForUpdate feedBackForUpdate)
    {
        FullName = feedBackForUpdate.FullName;
        Title = feedBackForUpdate.Title;
        Email = feedBackForUpdate.Email;
        PhoneNumber = feedBackForUpdate.PhoneNumber;
        FeedBackOnMV = feedBackForUpdate.FeedBackOnMV;

        QueueDomainEvent(new FeedBackUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected FeedBack() { } // For EF + Mocking
}
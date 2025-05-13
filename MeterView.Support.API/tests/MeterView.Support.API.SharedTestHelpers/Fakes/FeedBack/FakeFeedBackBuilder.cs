namespace MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;

using MeterView.Support.API.Domain.FeedBacks;
using MeterView.Support.API.Domain.FeedBacks.Models;

public class FakeFeedBackBuilder
{
    private FeedBackForCreation _creationData = new FakeFeedBackForCreation().Generate();

    public FakeFeedBackBuilder WithModel(FeedBackForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeFeedBackBuilder WithFullName(string fullName)
    {
        _creationData.FullName = fullName;
        return this;
    }
    
    public FakeFeedBackBuilder WithTitle(string title)
    {
        _creationData.Title = title;
        return this;
    }
    
    public FakeFeedBackBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public FakeFeedBackBuilder WithPhoneNumber(string phoneNumber)
    {
        _creationData.PhoneNumber = phoneNumber;
        return this;
    }
    
    public FakeFeedBackBuilder WithFeedBackOnMV(string feedBackOnMV)
    {
        _creationData.FeedBackOnMV = feedBackOnMV;
        return this;
    }
    
    public FeedBack Build()
    {
        var result = FeedBack.Create(_creationData);
        return result;
    }
}
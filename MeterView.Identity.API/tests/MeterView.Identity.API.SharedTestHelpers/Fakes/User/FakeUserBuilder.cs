namespace MeterView.Identity.API.SharedTestHelpers.Fakes.User;

using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.Models;

public class FakeUserBuilder
{
    private UserForCreation _creationData = new FakeUserForCreation().Generate();

    public FakeUserBuilder WithModel(UserForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeUserBuilder WithEmail(string email)
    {
        _creationData.Email = email;
        return this;
    }
    
    public FakeUserBuilder WithUserName(string userName)
    {
        _creationData.UserName = userName;
        return this;
    }
    
    public FakeUserBuilder WithGivenName(string givenName)
    {
        _creationData.GivenName = givenName;
        return this;
    }
    
    public FakeUserBuilder WithFamilyName(string familyName)
    {
        _creationData.FamilyName = familyName;
        return this;
    }
    
    public FakeUserBuilder WithNickName(string nickName)
    {
        _creationData.NickName = nickName;
        return this;
    }
    
    public FakeUserBuilder WithEmailVerified(bool emailVerified)
    {
        _creationData.EmailVerified = emailVerified;
        return this;
    }
    
    public FakeUserBuilder WithPassword(string password)
    {
        _creationData.Password = password;
        return this;
    }
    
    public FakeUserBuilder WithGender(string gender)
    {
        _creationData.Gender = gender;
        return this;
    }
    
    public FakeUserBuilder WithLanguage(string language)
    {
        _creationData.Language = language;
        return this;
    }
    
    public FakeUserBuilder WithPhoneNumber(string phoneNumber)
    {
        _creationData.PhoneNumber = phoneNumber;
        return this;
    }
    
    public User Build()
    {
        var result = User.Create(_creationData);
        return result;
    }
}
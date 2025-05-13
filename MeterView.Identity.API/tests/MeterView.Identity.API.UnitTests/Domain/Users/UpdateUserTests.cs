namespace MeterView.Identity.API.UnitTests.Domain.Users;

using MeterView.Identity.API.SharedTestHelpers.Fakes.User;
using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class UpdateUserTests
{
    private readonly Faker _faker;

    public UpdateUserTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_user()
    {
        // Arrange
        var user = new FakeUserBuilder().Build();
        var updatedUser = new FakeUserForUpdate().Generate();
        
        // Act
        user.Update(updatedUser);

        // Assert
        user.Email.Should().Be(updatedUser.Email);
        user.UserName.Should().Be(updatedUser.UserName);
        user.GivenName.Should().Be(updatedUser.GivenName);
        user.FamilyName.Should().Be(updatedUser.FamilyName);
        user.NickName.Should().Be(updatedUser.NickName);
        user.EmailVerified.Should().Be(updatedUser.EmailVerified);
        user.Password.Should().Be(updatedUser.Password);
        user.Gender.Should().Be(updatedUser.Gender);
        user.Language.Should().Be(updatedUser.Language);
        user.PhoneNumber.Should().Be(updatedUser.PhoneNumber);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var user = new FakeUserBuilder().Build();
        var updatedUser = new FakeUserForUpdate().Generate();
        user.DomainEvents.Clear();
        
        // Act
        user.Update(updatedUser);

        // Assert
        user.DomainEvents.Count.Should().Be(1);
        user.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(UserUpdated));
    }
}
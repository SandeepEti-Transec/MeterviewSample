namespace MeterView.Identity.API.UnitTests.Domain.Users;

using MeterView.Identity.API.SharedTestHelpers.Fakes.User;
using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class CreateUserTests
{
    private readonly Faker _faker;

    public CreateUserTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_user()
    {
        // Arrange
        var userToCreate = new FakeUserForCreation().Generate();
        
        // Act
        var user = User.Create(userToCreate);

        // Assert
        user.Email.Should().Be(userToCreate.Email);
        user.UserName.Should().Be(userToCreate.UserName);
        user.GivenName.Should().Be(userToCreate.GivenName);
        user.FamilyName.Should().Be(userToCreate.FamilyName);
        user.NickName.Should().Be(userToCreate.NickName);
        user.EmailVerified.Should().Be(userToCreate.EmailVerified);
        user.Password.Should().Be(userToCreate.Password);
        user.Gender.Should().Be(userToCreate.Gender);
        user.Language.Should().Be(userToCreate.Language);
        user.PhoneNumber.Should().Be(userToCreate.PhoneNumber);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var userToCreate = new FakeUserForCreation().Generate();
        
        // Act
        var user = User.Create(userToCreate);

        // Assert
        user.DomainEvents.Count.Should().Be(1);
        user.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(UserCreated));
    }
}
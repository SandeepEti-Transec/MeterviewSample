namespace MeterView.Identity.API.Domain.Users;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Domain.Users.Models;
using MeterView.Identity.API.Domain.Users.DomainEvents;


public class User : BaseEntity
{
    [Required]
    public string Email { get; private set; }

    [Required]
    public string UserName { get; private set; }

    [Required]
    public string GivenName { get; private set; }

    [Required]
    public string FamilyName { get; private set; }

    public string NickName { get; private set; }

    public bool EmailVerified { get; private set; }

    public string Password { get; private set; }

    public string Gender { get; private set; }

    public string Language { get; private set; }

    public string PhoneNumber { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static User Create(UserForCreation userForCreation)
    {
        var newUser = new User();

        newUser.Email = userForCreation.Email;
        newUser.UserName = userForCreation.UserName;
        newUser.GivenName = userForCreation.GivenName;
        newUser.FamilyName = userForCreation.FamilyName;
        newUser.NickName = userForCreation.NickName;
        newUser.EmailVerified = userForCreation.EmailVerified;
        newUser.Password = userForCreation.Password;
        newUser.Gender = userForCreation.Gender;
        newUser.Language = userForCreation.Language;
        newUser.PhoneNumber = userForCreation.PhoneNumber;

        newUser.QueueDomainEvent(new UserCreated(){ User = newUser });
        
        return newUser;
    }

    public User Update(UserForUpdate userForUpdate)
    {
        Email = userForUpdate.Email;
        UserName = userForUpdate.UserName;
        GivenName = userForUpdate.GivenName;
        FamilyName = userForUpdate.FamilyName;
        NickName = userForUpdate.NickName;
        EmailVerified = userForUpdate.EmailVerified;
        Password = userForUpdate.Password;
        Gender = userForUpdate.Gender;
        Language = userForUpdate.Language;
        PhoneNumber = userForUpdate.PhoneNumber;

        QueueDomainEvent(new UserUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected User() { } // For EF + Mocking
}
namespace MeterView.Identity.API.Domain.UserOgranizations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Domain.UserOgranizations.Models;
using MeterView.Identity.API.Domain.UserOgranizations.DomainEvents;
using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.Models;
using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.Models;


public class UserOgranization : BaseEntity
{
    [Required]
    public int UserId { get; private set; }

    [Required]
    public int OrganizationId { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static UserOgranization Create(UserOgranizationForCreation userOgranizationForCreation)
    {
        var newUserOgranization = new UserOgranization();

        newUserOgranization.UserId = userOgranizationForCreation.UserId;
        newUserOgranization.OrganizationId = userOgranizationForCreation.OrganizationId;

        newUserOgranization.QueueDomainEvent(new UserOgranizationCreated(){ UserOgranization = newUserOgranization });
        
        return newUserOgranization;
    }

    public UserOgranization Update(UserOgranizationForUpdate userOgranizationForUpdate)
    {
        UserId = userOgranizationForUpdate.UserId;
        OrganizationId = userOgranizationForUpdate.OrganizationId;

        QueueDomainEvent(new UserOgranizationUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected UserOgranization() { } // For EF + Mocking
}
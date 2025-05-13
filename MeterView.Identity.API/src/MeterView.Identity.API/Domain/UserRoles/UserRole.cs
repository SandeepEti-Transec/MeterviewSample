namespace MeterView.Identity.API.Domain.UserRoles;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Domain.UserRoles.Models;
using MeterView.Identity.API.Domain.UserRoles.DomainEvents;


public class UserRole : BaseEntity
{
    [Required]
    public int UserId { get; private set; }

    [Required]
    public int RoleId { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static UserRole Create(UserRoleForCreation userRoleForCreation)
    {
        var newUserRole = new UserRole();

        newUserRole.UserId = userRoleForCreation.UserId;
        newUserRole.RoleId = userRoleForCreation.RoleId;

        newUserRole.QueueDomainEvent(new UserRoleCreated(){ UserRole = newUserRole });
        
        return newUserRole;
    }

    public UserRole Update(UserRoleForUpdate userRoleForUpdate)
    {
        UserId = userRoleForUpdate.UserId;
        RoleId = userRoleForUpdate.RoleId;

        QueueDomainEvent(new UserRoleUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected UserRole() { } // For EF + Mocking
}
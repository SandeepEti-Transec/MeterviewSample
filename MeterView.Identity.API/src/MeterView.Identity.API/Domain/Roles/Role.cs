namespace MeterView.Identity.API.Domain.Roles;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Domain.Roles.Models;
using MeterView.Identity.API.Domain.Roles.DomainEvents;


public class Role : BaseEntity
{
    [Required]
    public string Key { get; private set; }

    public string DisplayName { get; private set; }

    public string Group { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Role Create(RoleForCreation roleForCreation)
    {
        var newRole = new Role();

        newRole.Key = roleForCreation.Key;
        newRole.DisplayName = roleForCreation.DisplayName;
        newRole.Group = roleForCreation.Group;

        newRole.QueueDomainEvent(new RoleCreated(){ Role = newRole });
        
        return newRole;
    }

    public Role Update(RoleForUpdate roleForUpdate)
    {
        Key = roleForUpdate.Key;
        DisplayName = roleForUpdate.DisplayName;
        Group = roleForUpdate.Group;

        QueueDomainEvent(new RoleUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Role() { } // For EF + Mocking
}
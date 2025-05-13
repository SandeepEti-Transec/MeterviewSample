namespace MeterView.Identity.API.Domain.Organizations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Domain.Organizations.Models;
using MeterView.Identity.API.Domain.Organizations.DomainEvents;


public class Organization : BaseEntity
{
    [Required]
    public string Name { get; private set; }

    [Required]
    public string PrimaryDomain { get; private set; }

    [Required]
    public bool IsActive { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static Organization Create(OrganizationForCreation organizationForCreation)
    {
        var newOrganization = new Organization();

        newOrganization.Name = organizationForCreation.Name;
        newOrganization.PrimaryDomain = organizationForCreation.PrimaryDomain;
        newOrganization.IsActive = organizationForCreation.IsActive;

        newOrganization.QueueDomainEvent(new OrganizationCreated(){ Organization = newOrganization });
        
        return newOrganization;
    }

    public Organization Update(OrganizationForUpdate organizationForUpdate)
    {
        Name = organizationForUpdate.Name;
        PrimaryDomain = organizationForUpdate.PrimaryDomain;
        IsActive = organizationForUpdate.IsActive;

        QueueDomainEvent(new OrganizationUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected Organization() { } // For EF + Mocking
}
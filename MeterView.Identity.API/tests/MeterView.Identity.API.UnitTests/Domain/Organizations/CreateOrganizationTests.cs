namespace MeterView.Identity.API.UnitTests.Domain.Organizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;
using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class CreateOrganizationTests
{
    private readonly Faker _faker;

    public CreateOrganizationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_organization()
    {
        // Arrange
        var organizationToCreate = new FakeOrganizationForCreation().Generate();
        
        // Act
        var organization = Organization.Create(organizationToCreate);

        // Assert
        organization.Name.Should().Be(organizationToCreate.Name);
        organization.PrimaryDomain.Should().Be(organizationToCreate.PrimaryDomain);
        organization.IsActive.Should().Be(organizationToCreate.IsActive);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var organizationToCreate = new FakeOrganizationForCreation().Generate();
        
        // Act
        var organization = Organization.Create(organizationToCreate);

        // Assert
        organization.DomainEvents.Count.Should().Be(1);
        organization.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrganizationCreated));
    }
}
namespace MeterView.Identity.API.UnitTests.Domain.Organizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;
using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class UpdateOrganizationTests
{
    private readonly Faker _faker;

    public UpdateOrganizationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_organization()
    {
        // Arrange
        var organization = new FakeOrganizationBuilder().Build();
        var updatedOrganization = new FakeOrganizationForUpdate().Generate();
        
        // Act
        organization.Update(updatedOrganization);

        // Assert
        organization.Name.Should().Be(updatedOrganization.Name);
        organization.PrimaryDomain.Should().Be(updatedOrganization.PrimaryDomain);
        organization.IsActive.Should().Be(updatedOrganization.IsActive);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var organization = new FakeOrganizationBuilder().Build();
        var updatedOrganization = new FakeOrganizationForUpdate().Generate();
        organization.DomainEvents.Clear();
        
        // Act
        organization.Update(updatedOrganization);

        // Assert
        organization.DomainEvents.Count.Should().Be(1);
        organization.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(OrganizationUpdated));
    }
}
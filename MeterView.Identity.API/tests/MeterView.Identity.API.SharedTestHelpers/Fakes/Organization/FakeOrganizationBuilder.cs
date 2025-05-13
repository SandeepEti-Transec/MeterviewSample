namespace MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;

using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.Models;

public class FakeOrganizationBuilder
{
    private OrganizationForCreation _creationData = new FakeOrganizationForCreation().Generate();

    public FakeOrganizationBuilder WithModel(OrganizationForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeOrganizationBuilder WithName(string name)
    {
        _creationData.Name = name;
        return this;
    }
    
    public FakeOrganizationBuilder WithPrimaryDomain(string primaryDomain)
    {
        _creationData.PrimaryDomain = primaryDomain;
        return this;
    }
    
    public FakeOrganizationBuilder WithIsActive(bool isActive)
    {
        _creationData.IsActive = isActive;
        return this;
    }
    
    public Organization Build()
    {
        var result = Organization.Create(_creationData);
        return result;
    }
}
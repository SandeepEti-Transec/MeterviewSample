namespace MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;

using MeterView.Identity.API.Domain.UserOgranizations;
using MeterView.Identity.API.Domain.UserOgranizations.Models;

public class FakeUserOgranizationBuilder
{
    private UserOgranizationForCreation _creationData = new FakeUserOgranizationForCreation().Generate();

    public FakeUserOgranizationBuilder WithModel(UserOgranizationForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeUserOgranizationBuilder WithUserId(int userId)
    {
        _creationData.UserId = userId;
        return this;
    }
    
    public FakeUserOgranizationBuilder WithOrganizationId(int organizationId)
    {
        _creationData.OrganizationId = organizationId;
        return this;
    }
    
    public UserOgranization Build()
    {
        var result = UserOgranization.Create(_creationData);
        return result;
    }
}
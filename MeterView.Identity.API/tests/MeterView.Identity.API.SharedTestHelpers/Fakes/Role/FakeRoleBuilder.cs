namespace MeterView.Identity.API.SharedTestHelpers.Fakes.Role;

using MeterView.Identity.API.Domain.Roles;
using MeterView.Identity.API.Domain.Roles.Models;

public class FakeRoleBuilder
{
    private RoleForCreation _creationData = new FakeRoleForCreation().Generate();

    public FakeRoleBuilder WithModel(RoleForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeRoleBuilder WithKey(string key)
    {
        _creationData.Key = key;
        return this;
    }
    
    public FakeRoleBuilder WithDisplayName(string displayName)
    {
        _creationData.DisplayName = displayName;
        return this;
    }
    
    public FakeRoleBuilder WithGroup(string group)
    {
        _creationData.Group = group;
        return this;
    }
    
    public Role Build()
    {
        var result = Role.Create(_creationData);
        return result;
    }
}
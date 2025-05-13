namespace MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;

using MeterView.Identity.API.Domain.UserRoles;
using MeterView.Identity.API.Domain.UserRoles.Models;

public class FakeUserRoleBuilder
{
    private UserRoleForCreation _creationData = new FakeUserRoleForCreation().Generate();

    public FakeUserRoleBuilder WithModel(UserRoleForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeUserRoleBuilder WithUserId(int userId)
    {
        _creationData.UserId = userId;
        return this;
    }
    
    public FakeUserRoleBuilder WithRoleId(int roleId)
    {
        _creationData.RoleId = roleId;
        return this;
    }
    
    public UserRole Build()
    {
        var result = UserRole.Create(_creationData);
        return result;
    }
}
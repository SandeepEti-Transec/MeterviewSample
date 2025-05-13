namespace MeterView.Identity.API.Domain.UserRoles.Models;

using Destructurama.Attributed;

public sealed record UserRoleForCreation
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}

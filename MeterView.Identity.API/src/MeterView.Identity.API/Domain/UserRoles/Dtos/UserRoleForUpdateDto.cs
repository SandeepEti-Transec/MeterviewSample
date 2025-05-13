namespace MeterView.Identity.API.Domain.UserRoles.Dtos;

using Destructurama.Attributed;

public sealed record UserRoleForUpdateDto
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}

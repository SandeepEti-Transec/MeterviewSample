namespace MeterView.Identity.API.Domain.UserRoles.Dtos;

using Destructurama.Attributed;

public sealed record UserRoleForCreationDto
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}

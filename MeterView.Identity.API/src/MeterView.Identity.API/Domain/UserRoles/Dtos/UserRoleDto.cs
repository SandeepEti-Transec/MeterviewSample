namespace MeterView.Identity.API.Domain.UserRoles.Dtos;

using Destructurama.Attributed;

public sealed record UserRoleDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}

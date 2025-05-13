namespace MeterView.Identity.API.Domain.Roles.Dtos;

using Destructurama.Attributed;

public sealed record RoleForUpdateDto
{
    public string Key { get; set; }
    public string DisplayName { get; set; }
    public string Group { get; set; }
}

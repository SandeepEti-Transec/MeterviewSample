namespace MeterView.Identity.API.Domain.Roles.Models;

using Destructurama.Attributed;

public sealed record RoleForUpdate
{
    public string Key { get; set; }
    public string DisplayName { get; set; }
    public string Group { get; set; }
}

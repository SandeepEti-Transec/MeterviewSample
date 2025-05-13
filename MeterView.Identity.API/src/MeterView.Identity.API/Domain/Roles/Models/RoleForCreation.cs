namespace MeterView.Identity.API.Domain.Roles.Models;

using Destructurama.Attributed;

public sealed record RoleForCreation
{
    public string Key { get; set; }
    public string DisplayName { get; set; }
    public string Group { get; set; }
}

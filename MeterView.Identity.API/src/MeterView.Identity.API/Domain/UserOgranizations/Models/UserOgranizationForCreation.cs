namespace MeterView.Identity.API.Domain.UserOgranizations.Models;

using Destructurama.Attributed;

public sealed record UserOgranizationForCreation
{
    public int UserId { get; set; }
    public int OrganizationId { get; set; }
}

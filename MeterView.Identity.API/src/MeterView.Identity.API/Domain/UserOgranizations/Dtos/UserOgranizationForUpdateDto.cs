namespace MeterView.Identity.API.Domain.UserOgranizations.Dtos;

using Destructurama.Attributed;

public sealed record UserOgranizationForUpdateDto
{
    public int UserId { get; set; }
    public int OrganizationId { get; set; }
}

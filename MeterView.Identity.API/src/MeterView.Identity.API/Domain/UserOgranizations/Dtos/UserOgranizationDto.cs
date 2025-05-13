namespace MeterView.Identity.API.Domain.UserOgranizations.Dtos;

using Destructurama.Attributed;

public sealed record UserOgranizationDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public int OrganizationId { get; set; }
}

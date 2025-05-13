namespace MeterView.Identity.API.Domain.Organizations.Dtos;

using Destructurama.Attributed;

public sealed record OrganizationForUpdateDto
{
    public string Name { get; set; }
    public string PrimaryDomain { get; set; }
    public bool IsActive { get; set; }
}

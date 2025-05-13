namespace MeterView.Identity.API.Domain.Organizations.Models;

using Destructurama.Attributed;

public sealed record OrganizationForUpdate
{
    public string Name { get; set; }
    public string PrimaryDomain { get; set; }
    public bool IsActive { get; set; }
}

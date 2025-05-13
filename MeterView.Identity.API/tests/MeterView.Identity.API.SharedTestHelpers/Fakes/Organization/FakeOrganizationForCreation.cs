namespace MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;

using AutoBogus;
using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.Models;

public sealed class FakeOrganizationForCreation : AutoFaker<OrganizationForCreation>
{
    public FakeOrganizationForCreation()
    {
    }
}
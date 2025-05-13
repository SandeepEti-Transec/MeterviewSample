namespace MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;

using AutoBogus;
using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.Dtos;

public sealed class FakeOrganizationForUpdateDto : AutoFaker<OrganizationForUpdateDto>
{
    public FakeOrganizationForUpdateDto()
    {
    }
}
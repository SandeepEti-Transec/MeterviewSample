namespace MeterView.Identity.API.Domain.Organizations.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.Dtos;
using MeterView.Identity.API.Domain.Organizations.Models;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class AddOrganization
{
    public sealed record Command(OrganizationForCreationDto OrganizationToAdd) : IRequest<OrganizationDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command, OrganizationDto>
    {
        public async Task<OrganizationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var organizationToAdd = request.OrganizationToAdd.ToOrganizationForCreation();
            var organization = Organization.Create(organizationToAdd);

            await dbContext.Organizations.AddAsync(organization, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return organization.ToOrganizationDto();
        }
    }
}
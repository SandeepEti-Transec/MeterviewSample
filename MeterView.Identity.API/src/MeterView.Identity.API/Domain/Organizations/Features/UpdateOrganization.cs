namespace MeterView.Identity.API.Domain.Organizations.Features;

using MeterView.Identity.API.Domain.Organizations;
using MeterView.Identity.API.Domain.Organizations.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Domain.Organizations.Models;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateOrganization
{
    public sealed record Command(Guid OrganizationId, OrganizationForUpdateDto UpdatedOrganizationData) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var organizationToUpdate = await dbContext.Organizations.GetById(request.OrganizationId, cancellationToken: cancellationToken);
            var organizationToAdd = request.UpdatedOrganizationData.ToOrganizationForUpdate();
            organizationToUpdate.Update(organizationToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
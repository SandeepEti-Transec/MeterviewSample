namespace MeterView.Identity.API.Domain.Organizations.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using MediatR;

public static class DeleteOrganization
{
    public sealed record Command(Guid OrganizationId) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.Organizations
                .GetById(request.OrganizationId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
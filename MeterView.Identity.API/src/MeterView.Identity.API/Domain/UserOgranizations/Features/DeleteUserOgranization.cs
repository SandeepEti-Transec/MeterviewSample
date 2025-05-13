namespace MeterView.Identity.API.Domain.UserOgranizations.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using MediatR;

public static class DeleteUserOgranization
{
    public sealed record Command(Guid UserOgranizationId) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.UserOgranizations
                .GetById(request.UserOgranizationId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
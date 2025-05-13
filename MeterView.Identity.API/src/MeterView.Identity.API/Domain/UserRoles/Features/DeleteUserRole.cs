namespace MeterView.Identity.API.Domain.UserRoles.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using MediatR;

public static class DeleteUserRole
{
    public sealed record Command(Guid UserRoleId) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.UserRoles
                .GetById(request.UserRoleId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
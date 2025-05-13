namespace MeterView.Identity.API.Domain.UserOgranizations.Features;

using MeterView.Identity.API.Domain.UserOgranizations;
using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Domain.UserOgranizations.Models;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateUserOgranization
{
    public sealed record Command(Guid UserOgranizationId, UserOgranizationForUpdateDto UpdatedUserOgranizationData) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var userOgranizationToUpdate = await dbContext.UserOgranizations.GetById(request.UserOgranizationId, cancellationToken: cancellationToken);
            var userOgranizationToAdd = request.UpdatedUserOgranizationData.ToUserOgranizationForUpdate();
            userOgranizationToUpdate.Update(userOgranizationToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
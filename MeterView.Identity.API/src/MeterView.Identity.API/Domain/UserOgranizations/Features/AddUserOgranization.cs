namespace MeterView.Identity.API.Domain.UserOgranizations.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Domain.UserOgranizations;
using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.Domain.UserOgranizations.Models;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class AddUserOgranization
{
    public sealed record Command(UserOgranizationForCreationDto UserOgranizationToAdd) : IRequest<UserOgranizationDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command, UserOgranizationDto>
    {
        public async Task<UserOgranizationDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userOgranizationToAdd = request.UserOgranizationToAdd.ToUserOgranizationForCreation();
            var userOgranization = UserOgranization.Create(userOgranizationToAdd);

            await dbContext.UserOgranizations.AddAsync(userOgranization, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return userOgranization.ToUserOgranizationDto();
        }
    }
}
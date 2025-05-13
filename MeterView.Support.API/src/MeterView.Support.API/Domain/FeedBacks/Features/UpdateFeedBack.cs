namespace MeterView.Support.API.Domain.FeedBacks.Features;

using MeterView.Support.API.Domain.FeedBacks;
using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.Databases;
using MeterView.Support.API.Services;
using MeterView.Support.API.Domain.FeedBacks.Models;
using MeterView.Support.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateFeedBack
{
    public sealed record Command(Guid FeedBackId, FeedBackForUpdateDto UpdatedFeedBackData) : IRequest;

    public sealed class Handler(SupportDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var feedBackToUpdate = await dbContext.FeedBacks.GetById(request.FeedBackId, cancellationToken: cancellationToken);
            var feedBackToAdd = request.UpdatedFeedBackData.ToFeedBackForUpdate();
            feedBackToUpdate.Update(feedBackToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
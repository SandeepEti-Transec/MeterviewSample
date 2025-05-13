namespace MeterView.Support.API.Domain.FeedBacks.Features;

using MeterView.Support.API.Databases;
using MeterView.Support.API.Domain.FeedBacks;
using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.Domain.FeedBacks.Models;
using MeterView.Support.API.Services;
using MeterView.Support.API.Exceptions;
using Mappings;
using MediatR;

public static class AddFeedBack
{
    public sealed record Command(FeedBackForCreationDto FeedBackToAdd) : IRequest<FeedBackDto>;

    public sealed class Handler(SupportDbContext dbContext)
        : IRequestHandler<Command, FeedBackDto>
    {
        public async Task<FeedBackDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var feedBackToAdd = request.FeedBackToAdd.ToFeedBackForCreation();
            var feedBack = FeedBack.Create(feedBackToAdd);

            await dbContext.FeedBacks.AddAsync(feedBack, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return feedBack.ToFeedBackDto();
        }
    }
}
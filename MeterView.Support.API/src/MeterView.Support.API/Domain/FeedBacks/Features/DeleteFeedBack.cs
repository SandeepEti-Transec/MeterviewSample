namespace MeterView.Support.API.Domain.FeedBacks.Features;

using MeterView.Support.API.Databases;
using MeterView.Support.API.Services;
using MeterView.Support.API.Exceptions;
using MediatR;

public static class DeleteFeedBack
{
    public sealed record Command(Guid FeedBackId) : IRequest;

    public sealed class Handler(SupportDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.FeedBacks
                .GetById(request.FeedBackId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
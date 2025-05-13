namespace MeterView.Support.API.Domain.FeedBacks.Features;

using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.Databases;
using MeterView.Support.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetFeedBack
{
    public sealed record Query(Guid FeedBackId) : IRequest<FeedBackDto>;

    public sealed class Handler(SupportDbContext dbContext)
        : IRequestHandler<Query, FeedBackDto>
    {
        public async Task<FeedBackDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.FeedBacks
                .AsNoTracking()
                .GetById(request.FeedBackId, cancellationToken);
            return result.ToFeedBackDto();
        }
    }
}
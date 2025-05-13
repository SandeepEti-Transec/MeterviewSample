namespace MeterView.TrendLines.API.Domain.TrendLines.Features;

using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.Databases;
using MeterView.TrendLines.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetTrendLine
{
    public sealed record Query(Guid TrendLineId) : IRequest<TrendLineDto>;

    public sealed class Handler(TrendLinesDbContext dbContext)
        : IRequestHandler<Query, TrendLineDto>
    {
        public async Task<TrendLineDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.TrendLines
                .AsNoTracking()
                .GetById(request.TrendLineId, cancellationToken);
            return result.ToTrendLineDto();
        }
    }
}
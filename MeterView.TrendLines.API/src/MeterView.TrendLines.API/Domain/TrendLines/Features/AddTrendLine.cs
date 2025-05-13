namespace MeterView.TrendLines.API.Domain.TrendLines.Features;

using MeterView.TrendLines.API.Databases;
using MeterView.TrendLines.API.Domain.TrendLines;
using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.Domain.TrendLines.Models;
using MeterView.TrendLines.API.Services;
using MeterView.TrendLines.API.Exceptions;
using Mappings;
using MediatR;

public static class AddTrendLine
{
    public sealed record Command(TrendLineForCreationDto TrendLineToAdd) : IRequest<TrendLineDto>;

    public sealed class Handler(TrendLinesDbContext dbContext)
        : IRequestHandler<Command, TrendLineDto>
    {
        public async Task<TrendLineDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var trendLineToAdd = request.TrendLineToAdd.ToTrendLineForCreation();
            var trendLine = TrendLine.Create(trendLineToAdd);

            await dbContext.TrendLines.AddAsync(trendLine, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return trendLine.ToTrendLineDto();
        }
    }
}
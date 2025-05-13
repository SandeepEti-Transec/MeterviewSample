namespace MeterView.TrendLines.API.Domain.TrendLines.Features;

using MeterView.TrendLines.API.Domain.TrendLines;
using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.Databases;
using MeterView.TrendLines.API.Services;
using MeterView.TrendLines.API.Domain.TrendLines.Models;
using MeterView.TrendLines.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateTrendLine
{
    public sealed record Command(Guid TrendLineId, TrendLineForUpdateDto UpdatedTrendLineData) : IRequest;

    public sealed class Handler(TrendLinesDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var trendLineToUpdate = await dbContext.TrendLines.GetById(request.TrendLineId, cancellationToken: cancellationToken);
            var trendLineToAdd = request.UpdatedTrendLineData.ToTrendLineForUpdate();
            trendLineToUpdate.Update(trendLineToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
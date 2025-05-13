namespace MeterView.TrendLines.API.Domain.TrendLines.Features;

using MeterView.TrendLines.API.Databases;
using MeterView.TrendLines.API.Services;
using MeterView.TrendLines.API.Exceptions;
using MediatR;

public static class DeleteTrendLine
{
    public sealed record Command(Guid TrendLineId) : IRequest;

    public sealed class Handler(TrendLinesDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var recordToDelete = await dbContext.TrendLines
                .GetById(request.TrendLineId, cancellationToken: cancellationToken);
            dbContext.Remove(recordToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
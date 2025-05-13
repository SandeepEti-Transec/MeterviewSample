namespace MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;

using AutoBogus;
using MeterView.TrendLines.API.Domain.TrendLines;
using MeterView.TrendLines.API.Domain.TrendLines.Dtos;

public sealed class FakeTrendLineForCreationDto : AutoFaker<TrendLineForCreationDto>
{
    public FakeTrendLineForCreationDto()
    {
    }
}
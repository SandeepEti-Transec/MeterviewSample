namespace MeterView.TrendLines.API.Domain.TrendLines.Mappings;

using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.Domain.TrendLines.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class TrendLineMapper
{
    public static partial TrendLineForCreation ToTrendLineForCreation(this TrendLineForCreationDto trendLineForCreationDto);
    public static partial TrendLineForUpdate ToTrendLineForUpdate(this TrendLineForUpdateDto trendLineForUpdateDto);
    public static partial TrendLineDto ToTrendLineDto(this TrendLine trendLine);
    public static partial IQueryable<TrendLineDto> ToTrendLineDtoQueryable(this IQueryable<TrendLine> trendLine);
}
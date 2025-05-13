namespace MeterView.Support.API.Domain.FeedBacks.Mappings;

using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.Domain.FeedBacks.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class FeedBackMapper
{
    public static partial FeedBackForCreation ToFeedBackForCreation(this FeedBackForCreationDto feedBackForCreationDto);
    public static partial FeedBackForUpdate ToFeedBackForUpdate(this FeedBackForUpdateDto feedBackForUpdateDto);
    public static partial FeedBackDto ToFeedBackDto(this FeedBack feedBack);
    public static partial IQueryable<FeedBackDto> ToFeedBackDtoQueryable(this IQueryable<FeedBack> feedBack);
}
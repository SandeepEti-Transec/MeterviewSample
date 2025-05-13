namespace MeterView.Notification.API.Domain.EmailTemplates.Dtos;

using MeterView.Notification.API.Resources;

public sealed class EmailTemplateParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}

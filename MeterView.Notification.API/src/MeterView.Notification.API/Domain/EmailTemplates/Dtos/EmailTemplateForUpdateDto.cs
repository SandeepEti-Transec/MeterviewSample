namespace MeterView.Notification.API.Domain.EmailTemplates.Dtos;

using Destructurama.Attributed;

public sealed record EmailTemplateForUpdateDto
{
    public string Context { get; set; }
    public string SubContext { get; set; }
    public string MailSubject { get; set; }
    public string HtmlText { get; set; }
    public bool HasPlaceholder { get; set; }
}

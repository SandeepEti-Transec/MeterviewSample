namespace MeterView.Notification.API.Domain.EmailTemplates.Models;

using Destructurama.Attributed;

public sealed record EmailTemplateForUpdate
{
    public string Context { get; set; }
    public string SubContext { get; set; }
    public string MailSubject { get; set; }
    public string HtmlText { get; set; }
    public bool HasPlaceholder { get; set; }
}

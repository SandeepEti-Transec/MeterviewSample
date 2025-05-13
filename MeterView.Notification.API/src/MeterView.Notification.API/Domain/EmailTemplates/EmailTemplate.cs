namespace MeterView.Notification.API.Domain.EmailTemplates;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.Notification.API.Exceptions;
using MeterView.Notification.API.Domain.EmailTemplates.Models;
using MeterView.Notification.API.Domain.EmailTemplates.DomainEvents;


public class EmailTemplate : BaseEntity
{
    [Required]
    public string Context { get; private set; }

    [Required]
    public string SubContext { get; private set; }

    [Required]
    public string MailSubject { get; private set; }

    [Required]
    public string HtmlText { get; private set; }

    [Required]
    public bool HasPlaceholder { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static EmailTemplate Create(EmailTemplateForCreation emailTemplateForCreation)
    {
        var newEmailTemplate = new EmailTemplate();

        newEmailTemplate.Context = emailTemplateForCreation.Context;
        newEmailTemplate.SubContext = emailTemplateForCreation.SubContext;
        newEmailTemplate.MailSubject = emailTemplateForCreation.MailSubject;
        newEmailTemplate.HtmlText = emailTemplateForCreation.HtmlText;
        newEmailTemplate.HasPlaceholder = emailTemplateForCreation.HasPlaceholder;

        newEmailTemplate.QueueDomainEvent(new EmailTemplateCreated(){ EmailTemplate = newEmailTemplate });
        
        return newEmailTemplate;
    }

    public EmailTemplate Update(EmailTemplateForUpdate emailTemplateForUpdate)
    {
        Context = emailTemplateForUpdate.Context;
        SubContext = emailTemplateForUpdate.SubContext;
        MailSubject = emailTemplateForUpdate.MailSubject;
        HtmlText = emailTemplateForUpdate.HtmlText;
        HasPlaceholder = emailTemplateForUpdate.HasPlaceholder;

        QueueDomainEvent(new EmailTemplateUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected EmailTemplate() { } // For EF + Mocking
}
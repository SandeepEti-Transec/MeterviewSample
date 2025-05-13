namespace MeterView.Notification.API.SharedTestHelpers.Fakes.EmailTemplate;

using MeterView.Notification.API.Domain.EmailTemplates;
using MeterView.Notification.API.Domain.EmailTemplates.Models;

public class FakeEmailTemplateBuilder
{
    private EmailTemplateForCreation _creationData = new FakeEmailTemplateForCreation().Generate();

    public FakeEmailTemplateBuilder WithModel(EmailTemplateForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeEmailTemplateBuilder WithContext(string context)
    {
        _creationData.Context = context;
        return this;
    }
    
    public FakeEmailTemplateBuilder WithSubContext(string subContext)
    {
        _creationData.SubContext = subContext;
        return this;
    }
    
    public FakeEmailTemplateBuilder WithMailSubject(string mailSubject)
    {
        _creationData.MailSubject = mailSubject;
        return this;
    }
    
    public FakeEmailTemplateBuilder WithHtmlText(string htmlText)
    {
        _creationData.HtmlText = htmlText;
        return this;
    }
    
    public FakeEmailTemplateBuilder WithHasPlaceholder(bool hasPlaceholder)
    {
        _creationData.HasPlaceholder = hasPlaceholder;
        return this;
    }
    
    public EmailTemplate Build()
    {
        var result = EmailTemplate.Create(_creationData);
        return result;
    }
}
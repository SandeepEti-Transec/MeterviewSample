namespace MeterView.Notification.API.SharedTestHelpers.Fakes.EmailTemplate;

using AutoBogus;
using MeterView.Notification.API.Domain.EmailTemplates;
using MeterView.Notification.API.Domain.EmailTemplates.Models;

public sealed class FakeEmailTemplateForCreation : AutoFaker<EmailTemplateForCreation>
{
    public FakeEmailTemplateForCreation()
    {
    }
}
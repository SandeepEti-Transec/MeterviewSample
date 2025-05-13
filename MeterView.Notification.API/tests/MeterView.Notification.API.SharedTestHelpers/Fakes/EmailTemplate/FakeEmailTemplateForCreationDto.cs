namespace MeterView.Notification.API.SharedTestHelpers.Fakes.EmailTemplate;

using AutoBogus;
using MeterView.Notification.API.Domain.EmailTemplates;
using MeterView.Notification.API.Domain.EmailTemplates.Dtos;

public sealed class FakeEmailTemplateForCreationDto : AutoFaker<EmailTemplateForCreationDto>
{
    public FakeEmailTemplateForCreationDto()
    {
    }
}
namespace MeterView.Notification.API.Domain.EmailTemplates.Mappings;

using MeterView.Notification.API.Domain.EmailTemplates.Dtos;
using MeterView.Notification.API.Domain.EmailTemplates.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class EmailTemplateMapper
{
    public static partial EmailTemplateForCreation ToEmailTemplateForCreation(this EmailTemplateForCreationDto emailTemplateForCreationDto);
    public static partial EmailTemplateForUpdate ToEmailTemplateForUpdate(this EmailTemplateForUpdateDto emailTemplateForUpdateDto);
    public static partial EmailTemplateDto ToEmailTemplateDto(this EmailTemplate emailTemplate);
    public static partial IQueryable<EmailTemplateDto> ToEmailTemplateDtoQueryable(this IQueryable<EmailTemplate> emailTemplate);
}
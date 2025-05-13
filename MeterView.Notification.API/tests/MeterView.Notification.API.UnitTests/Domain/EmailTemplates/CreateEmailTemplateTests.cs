namespace MeterView.Notification.API.UnitTests.Domain.EmailTemplates;

using MeterView.Notification.API.SharedTestHelpers.Fakes.EmailTemplate;
using MeterView.Notification.API.Domain.EmailTemplates;
using MeterView.Notification.API.Domain.EmailTemplates.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Notification.API.Exceptions.ValidationException;

public class CreateEmailTemplateTests
{
    private readonly Faker _faker;

    public CreateEmailTemplateTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_emailTemplate()
    {
        // Arrange
        var emailTemplateToCreate = new FakeEmailTemplateForCreation().Generate();
        
        // Act
        var emailTemplate = EmailTemplate.Create(emailTemplateToCreate);

        // Assert
        emailTemplate.Context.Should().Be(emailTemplateToCreate.Context);
        emailTemplate.SubContext.Should().Be(emailTemplateToCreate.SubContext);
        emailTemplate.MailSubject.Should().Be(emailTemplateToCreate.MailSubject);
        emailTemplate.HtmlText.Should().Be(emailTemplateToCreate.HtmlText);
        emailTemplate.HasPlaceholder.Should().Be(emailTemplateToCreate.HasPlaceholder);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var emailTemplateToCreate = new FakeEmailTemplateForCreation().Generate();
        
        // Act
        var emailTemplate = EmailTemplate.Create(emailTemplateToCreate);

        // Assert
        emailTemplate.DomainEvents.Count.Should().Be(1);
        emailTemplate.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EmailTemplateCreated));
    }
}
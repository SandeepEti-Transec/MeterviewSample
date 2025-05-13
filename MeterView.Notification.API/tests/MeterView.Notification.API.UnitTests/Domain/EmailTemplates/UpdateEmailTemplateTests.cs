namespace MeterView.Notification.API.UnitTests.Domain.EmailTemplates;

using MeterView.Notification.API.SharedTestHelpers.Fakes.EmailTemplate;
using MeterView.Notification.API.Domain.EmailTemplates;
using MeterView.Notification.API.Domain.EmailTemplates.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Notification.API.Exceptions.ValidationException;

public class UpdateEmailTemplateTests
{
    private readonly Faker _faker;

    public UpdateEmailTemplateTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_emailTemplate()
    {
        // Arrange
        var emailTemplate = new FakeEmailTemplateBuilder().Build();
        var updatedEmailTemplate = new FakeEmailTemplateForUpdate().Generate();
        
        // Act
        emailTemplate.Update(updatedEmailTemplate);

        // Assert
        emailTemplate.Context.Should().Be(updatedEmailTemplate.Context);
        emailTemplate.SubContext.Should().Be(updatedEmailTemplate.SubContext);
        emailTemplate.MailSubject.Should().Be(updatedEmailTemplate.MailSubject);
        emailTemplate.HtmlText.Should().Be(updatedEmailTemplate.HtmlText);
        emailTemplate.HasPlaceholder.Should().Be(updatedEmailTemplate.HasPlaceholder);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var emailTemplate = new FakeEmailTemplateBuilder().Build();
        var updatedEmailTemplate = new FakeEmailTemplateForUpdate().Generate();
        emailTemplate.DomainEvents.Clear();
        
        // Act
        emailTemplate.Update(updatedEmailTemplate);

        // Assert
        emailTemplate.DomainEvents.Count.Should().Be(1);
        emailTemplate.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(EmailTemplateUpdated));
    }
}
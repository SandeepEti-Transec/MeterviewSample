namespace MeterView.Notification.API.IntegrationTests.FeatureTests.EmailTemplates;

using MeterView.Notification.API.Domain.EmailTemplates.Dtos;
using MeterView.Notification.API.SharedTestHelpers.Fakes.EmailTemplate;
using MeterView.Notification.API.Domain.EmailTemplates.Features;
using Domain;
using System.Threading.Tasks;

public class EmailTemplateListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_emailtemplate_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var emailTemplateOne = new FakeEmailTemplateBuilder().Build();
        var emailTemplateTwo = new FakeEmailTemplateBuilder().Build();
        var queryParameters = new EmailTemplateParametersDto();

        await testingServiceScope.InsertAsync(emailTemplateOne, emailTemplateTwo);

        // Act
        var query = new GetEmailTemplateList.Query(queryParameters);
        var emailTemplates = await testingServiceScope.SendAsync(query);

        // Assert
        emailTemplates.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}
namespace MeterView.Alarms.API.IntegrationTests.FeatureTests.Alarms;

using MeterView.Alarms.API.Domain.Alarms.Dtos;
using MeterView.Alarms.API.SharedTestHelpers.Fakes.Alarm;
using MeterView.Alarms.API.Domain.Alarms.Features;
using Domain;
using System.Threading.Tasks;

public class AlarmListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_alarm_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var alarmOne = new FakeAlarmBuilder().Build();
        var alarmTwo = new FakeAlarmBuilder().Build();
        var queryParameters = new AlarmParametersDto();

        await testingServiceScope.InsertAsync(alarmOne, alarmTwo);

        // Act
        var query = new GetAlarmList.Query(queryParameters);
        var alarms = await testingServiceScope.SendAsync(query);

        // Assert
        alarms.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}
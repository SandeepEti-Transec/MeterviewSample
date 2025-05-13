namespace MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;

using MeterView.TrendLines.API.Domain.TrendLines;
using MeterView.TrendLines.API.Domain.TrendLines.Models;

public class FakeTrendLineBuilder
{
    private TrendLineForCreation _creationData = new FakeTrendLineForCreation().Generate();

    public FakeTrendLineBuilder WithModel(TrendLineForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeTrendLineBuilder WithName(string name)
    {
        _creationData.Name = name;
        return this;
    }
    
    public TrendLine Build()
    {
        var result = TrendLine.Create(_creationData);
        return result;
    }
}
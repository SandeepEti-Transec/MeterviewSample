namespace MeterView.TrendLines.API.Domain.TrendLines;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using MeterView.TrendLines.API.Exceptions;
using MeterView.TrendLines.API.Domain.TrendLines.Models;
using MeterView.TrendLines.API.Domain.TrendLines.DomainEvents;


public class TrendLine : BaseEntity
{
    public string Name { get; private set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static TrendLine Create(TrendLineForCreation trendLineForCreation)
    {
        var newTrendLine = new TrendLine();

        newTrendLine.Name = trendLineForCreation.Name;

        newTrendLine.QueueDomainEvent(new TrendLineCreated(){ TrendLine = newTrendLine });
        
        return newTrendLine;
    }

    public TrendLine Update(TrendLineForUpdate trendLineForUpdate)
    {
        Name = trendLineForUpdate.Name;

        QueueDomainEvent(new TrendLineUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected TrendLine() { } // For EF + Mocking
}
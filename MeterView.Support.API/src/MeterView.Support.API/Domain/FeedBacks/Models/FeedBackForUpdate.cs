namespace MeterView.Support.API.Domain.FeedBacks.Models;

using Destructurama.Attributed;

public sealed record FeedBackForUpdate
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FeedBackOnMV { get; set; }
}

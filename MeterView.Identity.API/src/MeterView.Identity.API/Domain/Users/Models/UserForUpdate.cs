namespace MeterView.Identity.API.Domain.Users.Models;

using Destructurama.Attributed;

public sealed record UserForUpdate
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string GivenName { get; set; }
    public string FamilyName { get; set; }
    public string NickName { get; set; }
    public bool EmailVerified { get; set; }
    public string Password { get; set; }
    public string Gender { get; set; }
    public string Language { get; set; }
    public string PhoneNumber { get; set; }
}

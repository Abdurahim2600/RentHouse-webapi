using Microsoft.AspNet.Identity.EntityFramework;
using RentHouse.Domain.Entities;
using RentHouse.Domain.Enums;

namespace RentHouse.DataAccess.ViewModel;

public class UserViewModel : Auditable
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string PassportSeriaNumber { get; set; } = String.Empty;

    public bool IsMale { get; set; }

    public DateOnly BirthDate { get; set; }

    public string ImagePath { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public DateTime LastActivity { get; set; }

}

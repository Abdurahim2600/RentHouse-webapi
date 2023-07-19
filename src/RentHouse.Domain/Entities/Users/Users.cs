using static System.Net.Mime.MediaTypeNames;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;

namespace RentHouse.Domain.Entities.Users;

public class Users : Auditable
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;
    [MaxLength(9)]
    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }

    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

}


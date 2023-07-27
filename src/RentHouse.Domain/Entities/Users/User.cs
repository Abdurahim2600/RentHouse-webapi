using static System.Net.Mime.MediaTypeNames;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;

namespace RentHouse.Domain.Entities.Users;

public class User : Auditable
{
    [Required(ErrorMessage = "name is reuired")]
    [MaxLength(50, ErrorMessage = "FirstName Must not exceed 50 characters")]
    [MinLength(3, ErrorMessage = "FirstName It should not be less than 3 characters")]

    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "name is reuired")]
    [MaxLength(50, ErrorMessage = "LastName Must not exceed 50 characters")]
    [MinLength(3, ErrorMessage = "LastName It should not be less than 3 characters")]
    public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Phone number is reuired")]
    [MaxLength(13, ErrorMessage = "Phone number Must be no more or less than 13 characters")]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required(ErrorMessage = "Passport Seria Number is reuired")]
    [MaxLength(9,ErrorMessage = "Passport seria number must not be less than 9 characters")]
    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }
    [Required(ErrorMessage = "Password is reuired")]
    [MinLength(8, ErrorMessage = "password must not be less than 8 characters ")]
    public string Password { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

}


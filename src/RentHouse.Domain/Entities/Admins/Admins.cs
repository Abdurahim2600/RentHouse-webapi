using System.ComponentModel.DataAnnotations;

namespace RentHouse.Domain.Entities.Admins;

public class Admins : Auditable
{
    [MaxLength(50)]

    public string FirstName { get; set; } = string.Empty;


    [MaxLength(50)]

    public string LastName { get; set; } = string.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public bool Ismale { get; set; }

    [MinLength(8)]
    public string Password { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}

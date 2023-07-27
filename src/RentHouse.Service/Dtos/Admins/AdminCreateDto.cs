using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RentHouse.Service.Dtos.Admins;

public class AdminCreateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    
    public IFormFile? ImagePath { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public bool Ismale { get; set; }

    public string Password { get; set; } = string.Empty;

}

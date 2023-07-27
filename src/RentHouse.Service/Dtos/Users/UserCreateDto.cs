using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RentHouse.Service.Dtos.Users;

public class UserCreateDto
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public string Passport { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateTime BirthDate { get; set; }

    public string Password { get; set; } = string.Empty;

    public IFormFile? ImagePath { get; set; }

    public string Email { get; set; } = string.Empty;

    
}

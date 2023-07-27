using Microsoft.AspNetCore.Http;

namespace RentHouse.Service.Dtos.Apartments;

public class ApartmentCreatedDto
{
    public string Describtion { get; set; } = string.Empty;

    public IFormFile ImagePath { get; set; } = default!;

    public double CommonPrice { get; set; }

    public double RoomCount { get; set; }

    public string Comment { get; set; } = string.Empty;

    
}

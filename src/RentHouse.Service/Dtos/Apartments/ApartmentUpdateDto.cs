using Microsoft.AspNetCore.Http;

namespace RentHouse.Service.Dtos.Apartments;

public class ApartmentUpdateDto : ApartmentCreatedDto
{
    public string Describtion { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public IFormFile Image_Path { get; set; } = default!;

    public double CommonPrice { get; set; }

    public double RoomCount { get; set; }
}

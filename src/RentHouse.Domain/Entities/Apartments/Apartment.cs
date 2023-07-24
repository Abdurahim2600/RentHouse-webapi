namespace RentHouse.Domain.Entities.Apartments;

public class Apartment : Auditable
{
    public string Describtion { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public string Image_Path { get; set; } = string.Empty;

    public double CommonPrice { get; set; }

    public double RoomCount { get; set; }


}

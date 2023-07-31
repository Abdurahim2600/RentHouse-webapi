namespace RentHouse.Domain.Entities.Apartments;

public class Apartment : Auditable
{
    public string Description { get; set; } = string.Empty;


    public double CommonPrice { get; set; }

    public double RoomCount { get; set; }
    public string ImagePath { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;


}

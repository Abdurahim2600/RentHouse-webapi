namespace RentHouse.Service.Dtos.Searchs;

public class SearchDto
{
    public string Description { get; set; } = string.Empty;

    public double CommonPrice { get; set; }

    public double RoomCount { get; set; }
}

namespace RentHouse.Domain.Entities.Apartment;

public class Appartments : Auditable
{
    public string Describtion { get; set; } = string.Empty;

    public string Adress { get; set; } = string.Empty;

    public string ImagePath1 { get; set; } = string.Empty;

    public string ImagePath2 { get; set; } = string.Empty;

    public string ImagePath3 { get; set; } = string.Empty;

    public string ImagePath4 { get; set; } = string.Empty;

    public double CommonPrice { get; set; }

    public double OneDayPrice { get; set; }


}

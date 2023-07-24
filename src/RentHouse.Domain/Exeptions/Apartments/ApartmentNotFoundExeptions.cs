namespace RentHouse.Domain.Exeptions.Apartments;

public class ApartmentNotFoundExeptions : NotFoundExseptions
{
    public ApartmentNotFoundExeptions()
    {
        this.TitleMessage = "Apartment not found!";
    }
}

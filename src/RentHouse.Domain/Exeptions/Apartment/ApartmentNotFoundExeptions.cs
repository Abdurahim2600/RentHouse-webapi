namespace RentHouse.Domain.Exeptions.Apartment;

public class ApartmentNotFoundExeptions : NotFoundExseptions
{
    public ApartmentNotFoundExeptions()
    {
        this.TitleMessage = "Apartment not found!";
    }
}

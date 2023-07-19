namespace RentHouse.Domain.Exeptions.Admin;

public class AdminNotFoundExeption : NotFoundExseptions
{
    public AdminNotFoundExeption()
    {
        this.TitleMessage = "Admin not found!"; 
    }
}

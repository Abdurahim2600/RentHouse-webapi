namespace RentHouse.Domain.Exeptions.Users;

public class UserNotFoundExeption : NotFoundExseptions
{
    public UserNotFoundExeption()
    {
        this.TitleMessage = "User not found!";
    }
}

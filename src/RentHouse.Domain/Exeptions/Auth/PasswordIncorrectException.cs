namespace RentHouse.Domain.Exeptions.Auth;

public class PasswordIncorrectException : BadRequestExeption
{
    public PasswordIncorrectException()
    {
        TitleMessage = "Password is Invvalid!";
    }
}

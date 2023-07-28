namespace RentHouse.Service.Commons.Healpers;

public class CodeGenerator
{
    public static int GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(1000, 9999);
    }
}

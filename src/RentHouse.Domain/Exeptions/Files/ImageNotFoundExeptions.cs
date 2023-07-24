namespace RentHouse.Domain.Exeptions.Files;

public class ImageNotFoundExeptions : NotFoundExseptions
{
    public ImageNotFoundExeptions()
    {
        this.TitleMessage = "Image not found!";
    }
}

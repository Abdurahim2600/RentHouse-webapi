namespace RentHouse.Domain.Exeptions.Category;

public class CategoryNotFoundExeptions : NotFoundExseptions
{
    public CategoryNotFoundExeptions()
    {
        this.TitleMessage = "Category Not Found!";
    }
}

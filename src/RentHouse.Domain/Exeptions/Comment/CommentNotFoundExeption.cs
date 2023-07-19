namespace RentHouse.Domain.Exeptions.Comment;

public class CommentNotFoundExeption : NotFoundExseptions
{
    public CommentNotFoundExeption()
    {
        this.TitleMessage = "Comment Not found!";
    }
}

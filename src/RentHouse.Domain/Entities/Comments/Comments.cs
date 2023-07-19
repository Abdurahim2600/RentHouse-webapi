namespace RentHouse.Domain.Entities.Comments;

public class Comments : Auditable
{
    public long ApartmentId { get; set; }

    public long UserId { get; set;}

    public string Comment { get; set; } = string.Empty;

    public bool IsEdited { get; set; }
}

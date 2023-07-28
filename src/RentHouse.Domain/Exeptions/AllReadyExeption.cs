using System.Net;

namespace RentHouse.Domain.Exeptions;

public class AllReadyExistsExeption : ClientExeption
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = String.Empty;
}

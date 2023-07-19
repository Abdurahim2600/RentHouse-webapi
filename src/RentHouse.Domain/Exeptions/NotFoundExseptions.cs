using System.Net;

namespace RentHouse.Domain.Exeptions;

public class NotFoundExseptions : Exception
{
    public HttpStatusCode StatusCode { get;} = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}

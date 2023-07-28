using System.Net;

namespace RentHouse.Domain.Exeptions;

public abstract class ClientExeption : Exception
{
    public abstract HttpStatusCode StatusCode { get; }

    public abstract string TitleMessage { get; protected set; }
    
}

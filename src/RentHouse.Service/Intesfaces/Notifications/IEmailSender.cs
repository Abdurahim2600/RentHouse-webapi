using RentHouse.Service.Dtos.Notifications;

namespace RentHouse.Service.Intesfaces.Notifications;

public interface IEmailSender
{
    public Task<bool> SendAsync(SmSMessage smSMessage);
}

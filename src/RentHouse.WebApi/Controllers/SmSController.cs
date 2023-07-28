using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Service.Dtos.Notifications;
using RentHouse.Service.Intesfaces.Notifications;

namespace RentHouse.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailSender _smsSender;
    public EmailController(IEmailSender smsSender)
    {
        this._smsSender = smsSender;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SendAsync([FromBody] SmSMessage smsMessage)
    {
        return Ok(await _smsSender.SendAsync(smsMessage));
    }
}
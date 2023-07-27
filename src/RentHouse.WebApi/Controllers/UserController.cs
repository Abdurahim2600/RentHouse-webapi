using Microsoft.AspNetCore.Mvc;
using RentHouse.DataAccess.Utils;
using RentHouse.Service.Dtos.Users;
using RentHouse.Service.Intesfaces.Users;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly int MaxPageSize = 30;
        public UserController(IUserService service)
        {
            this._service = service;
        }
        [HttpGet("Get-All")]

        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));


        [HttpGet]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(long getbyid)
            => Ok(await _service.GetByIdAsync(getbyid));


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(long userId)
            => Ok(await _service.DeleteAsync(userId));

    }
}

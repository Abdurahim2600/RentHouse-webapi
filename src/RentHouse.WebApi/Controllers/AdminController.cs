using Microsoft.AspNetCore.Mvc;
using RentHouse.DataAccess.Utils;
using RentHouse.Service.Dtos.Admins;
using RentHouse.Service.Intesfaces.Admins;

namespace RentHouse.WebApi.Controllers;

[Route("api/Admin")]
[ApiController]
public class AdminController : ControllerBase
{

    private readonly IAdminService _service;
    private readonly int MaxPageSize = 30;
    public AdminController(IAdminService service)
    {
        this._service = service;
    }
    [HttpGet("Get-All")]

    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));


    [HttpGet]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpGet("{getbyid}")]
    public async Task<IActionResult> GetByIdAsync(long getbyid)
        => Ok(await _service.GetByIdAsync(getbyid));


    [HttpPost]
    public async Task<IActionResult> CreateAsyncs([FromForm] AdminCreateDto dto)
        => Accepted(await _service.CreateAsync(dto));

    [HttpDelete]

    public async Task<IActionResult> DeleteAsync(long adminId)
        => Ok(await _service.DeleteAsync(adminId));




}

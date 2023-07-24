using Microsoft.AspNetCore.Mvc;
using RentHouse.DataAccess.Utils;
using RentHouse.Service.Dtos.Apartments;
using RentHouse.Service.Intesfaces.Apartments;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartmentController : ControllerBase
    {

        private readonly IApartmentService _service;
        private readonly int MaxPageSize = 30;
        public AppartmentController(IApartmentService service)
        {
            this._service = service;
        }
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));

        [HttpPut("{apartmentId}")]

        public async Task<IActionResult> UpdateAsync(long apartmentId, [FromBody] ApartmentUpdateDto dto)
            =>Ok(await _service.UpdateAsync(apartmentId, dto)); 

        [HttpGet]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());
        [HttpGet("GetBYId")]

        public async Task<IActionResult> GetByIdAsync(long id)
            => Ok(await _service.GetByIdAsync(id));


        [HttpPost]

        public async Task<IActionResult> CreateAsyncs([FromForm] ApartmentCreatedDto dto)
            => Accepted(await _service.CreateAsync(dto));

        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(long apartmentid)
            => Ok(await _service.DeleteAsync(apartmentid));


    }
}

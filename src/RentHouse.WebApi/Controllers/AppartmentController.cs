using Microsoft.AspNetCore.Mvc;
using RentHouse.DataAccess.Utils;
using RentHouse.Service.Dtos.Apartments;
using RentHouse.Service.Intesfaces.Apartments;
using RentHouse.Service.Validators.Dtos.Apartments;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/apartment")]
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

        public async Task<IActionResult> UpdateAsync(long apartmentId, [FromForm] ApartmentUpdateDto dto)
        {
            var updateValidator = new ApartmentUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(apartmentId, dto));
            else return BadRequest(validationResult.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());
        
        [HttpGet("{getbyid}")]
        public async Task<IActionResult> GetByIdAsync(long getbyid)
            => Ok(await _service.GetByIdAsync(getbyid));


        [HttpPost]
        public async Task<IActionResult> CreateAsyncs([FromForm] ApartmentCreatedDto dto)
        {
            var Valid = new ApartmentCreateValidator();
            var result = Valid.Validate(dto);
            if (result.IsValid)return Accepted(await _service.CreateAsync(dto));
            else { return BadRequest(result.Errors); }
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(long apartmentid)
            => Ok(await _service.DeleteAsync(apartmentid));
    }
}

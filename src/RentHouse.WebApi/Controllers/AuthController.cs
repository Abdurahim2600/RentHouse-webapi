using FluentValidation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentHouse.Service.Dtos.Auth;
using RentHouse.Service.Intesfaces.Auth;
using RentHouse.Service.Services.Auth;
using RentHouse.Service.Validators.Dtos;
using RentHouse.Service.Validators.Dtos.Auth;

namespace RentHouse.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservise;

        public AuthController(IAuthService authService)
        {
            this._authservise = authService;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
        {
            var validator = new RegistorValidator();
            var result = validator.Validate(registerDto);
            if (result.IsValid)
            {
                var serviseResult = await _authservise.RegisterAsync(registerDto);
                return Ok(new { serviseResult.Result, serviseResult.CachedMinutes });
            }
            else return BadRequest(result.Errors);
        }


        [HttpPost("register/send-code")]
        [AllowAnonymous]
        public async Task<IActionResult> SendCodeRegisterAsync(string email)
        {
            var result = EmailValidators.IsValid(email);
            if (result == false) return BadRequest("Email number is invalid!");

            var serviceResult = await _authservise.SendCodeForRegisterAsync(email);
            return Ok(new { serviceResult.Result, serviceResult.CachedVerificationMinutes });
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var validator = new LoginValidator();
            var valResult = validator.Validate(loginDto);
            if (valResult.IsValid == false) return BadRequest(valResult.Errors);

            var serviceResult = await _authservise.LoginAsync(loginDto);
            return Ok(new { serviceResult.Result, serviceResult.Token });
        }


        [HttpPost("register/verify")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto verifyRegisterDto)
        {
            var serviceResult = await _authservise.VerifyRegisterAsync(verifyRegisterDto.Email, verifyRegisterDto.Code);
            return Ok(new { serviceResult.Result, serviceResult.Token });
        }

    }
}

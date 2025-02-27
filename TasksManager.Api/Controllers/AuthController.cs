using Microsoft.AspNetCore.Mvc;
using TasksManager.Api.DTOs;
using TasksManager.Api.Services.Interfaces;

namespace TasksManager.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponseDto _responseDto = new();

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto request)
        {
            try
            {
                var registeredUser = await _authService.Register(request);

                if (registeredUser != null)
                {
                    _responseDto.Success = true;
                    _responseDto.Message = "User registered correctly";
                    _responseDto.Result = registeredUser;

                    return Ok(_responseDto);
                }
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;


                return BadRequest(_responseDto);

            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var login = await _authService.Login(request);

                _responseDto.Result = login;
                _responseDto.Success = true;
                _responseDto.Message = "Welcome back!";

                return Ok(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;

                return BadRequest(_responseDto);
            }
        }
    }
}

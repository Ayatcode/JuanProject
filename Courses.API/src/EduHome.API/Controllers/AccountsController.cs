using EduHome.Buisness.DTIOs.Auth;
using EduHome.Buisness.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        

        public async  Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                await _authService.RegisterAsync(registerDTO);
                return Ok(StatusCode(200));
            }
            catch (Exception )
            {
                return BadRequest();
            }
           

        }

        [HttpPost("[action]")]
        
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var tokenresponse = await _authService.Login(loginDTO);
                return Ok(loginDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

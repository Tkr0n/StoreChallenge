using Domain.Models;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OAuthController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IOAuthService _login;
        public OAuthController(IOAuthService login) 
        {
            _login = login;
        }

        [HttpPost]
        [Route("singup")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> SignUp(SignUp_Request request)
        {
            if (!request.ModelIsValid())
                return BadRequest(request);

            var token = await _login.SignUp(request);

            return Ok(new { Token = token });
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Login(Login_Request request)
        {
            if (!request.ModelIsValid())
                return BadRequest(request);

            var token = await _login.Login(request);

            return Ok(new {Token = token});
        }
    }
}

using BuberDinner.Application;
using BuberDinner.Contracts;
using BuberDinner.Contracts.Authantication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            AuthenticationResult result = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            return Ok(new AuthenticationResponse(
                result.Id,
                result.FirstName,
                result.LastName,
                result.Email,
                result.token));
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            AuthenticationResult result = _authenticationService.Login(
                request.Email,
                request.Password);


            return Ok(new AuthenticationResponse(
                result.Id,
                result.FirstName,
                result.LastName,
                result.Email,
                result.token));
        }
    }
}

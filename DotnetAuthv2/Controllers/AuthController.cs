using DotnetAuthv2.Entities;
using DotnetAuthv2.Entities.Models;
using DotnetAuthv2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAuthv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
                return BadRequest("User already exists");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var result = await authService.LoginAsync(request);
            if (result is null)
                return BadRequest("Invalid credentials");
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO refreshTokenRequestDTO)
        {
            var result = await authService.RefreshTokensAsync(refreshTokenRequestDTO);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return BadRequest("Invalid refresh token");
            return Ok(result);
        }

        [Authorize(Roles = "Admin, Supervisor")]
        [HttpGet("admin")]
        public ActionResult<string> AdminEndpoint()
        {
            return Ok("This is an admin endpoint");
        }
    }
    }

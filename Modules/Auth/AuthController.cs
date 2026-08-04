using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Roznama.Common.Constants;
using Roznama.Common.Responses;
using Roznama.Models.Auth;

namespace Roznama.Modules.Auth
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        [HttpPost(ApiRoutes.Auth.Login)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            try
            {
                var result = await _service.LoginAsync(req.Username, req.Password);

                if (result == null)
                    return Ok(ApiResponse<object>.Fail("Invalid credentials"));

                return Ok(ApiResponse<LoginResponse>.Ok(result, "Login successful"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<object>.Fail(
                    "Login failed",
                    new List<string> { ex.Message }
                ));
            }
        }
    }
}
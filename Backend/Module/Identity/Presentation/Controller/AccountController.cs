using Identity.Interfaces.IApplication;
using Identity.Models.Account;
using Identity.Presentation.DTO.Account;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IAccountApplication accountApplication) : ControllerBase
    {
        private readonly IAccountApplication _accountApplication = accountApplication;

        #region POST

        [RequireHttps]
        [HttpPost("register")]
        public async Task<ActionResult<AccountModel>> RegisterAsync(RegisterOrLoginRequest request, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest("Email is required.");
            }
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Password is required.");
            }

            try
            {
                var result = await _accountApplication.RegisterAsync(request.Email, request.Password, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
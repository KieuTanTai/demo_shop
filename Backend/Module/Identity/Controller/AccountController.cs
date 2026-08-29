using Identity.Interfaces.IApplication;
using Identity.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controller
{
    public class AccountController(IAccountApplication accountApplication) : ControllerBase
    {
        private readonly IAccountApplication _accountApplication = accountApplication;

        #region POST

        [RequireHttps]
        [HttpPost("register")]
        public async Task<ActionResult<AccountModel>> RegisterAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var result = await _accountApplication.RegisterAsync(email, password, cancellationToken);
            return Ok(result);
        }

        #endregion
    }
}
using Identity.Presentation.Record;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;

namespace Frontend.Controllers
{
    public class AuthController(IHttpClientFactory clientFactory, IOptions<MvcJsonOptions> jsonOptions) : Controller
    {
        private readonly IHttpClientFactory _clientFactory = clientFactory;
        private readonly JsonSerializerOptions _jsonSerializerOptions = jsonOptions.Value.JsonSerializerOptions;

        [RequireHttps]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] RecordAuthAndRegistrationRequest requestDto,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var client = _clientFactory.CreateClient("BackendApiIdentityHttps");
                var response = await client.PostAsJsonAsync("api/account/loginRequest", requestDto, cancellationToken);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync(cancellationToken);
                    return StatusCode((int)response.StatusCode, error);
                }

                var responseData = await response.Content.ReadFromJsonAsync<RecordAuthAndRegistrationResponse>(
                    _jsonSerializerOptions, cancellationToken);

                return Ok(responseData);
            }
            catch (OperationCanceledException)
            {
                return BadRequest("Login request was canceled.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

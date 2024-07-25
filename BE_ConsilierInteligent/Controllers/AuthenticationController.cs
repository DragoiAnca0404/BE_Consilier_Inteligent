using BE_ConsilierInteligent.Application.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BE_ConsilierInteligent.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {


        private AuthBLL _BLL;

        private readonly IConfiguration _config;

        public AuthenticationController(IConfiguration config)
        {
            _config = config;

        }

        [HttpPost("login/")]
        public IActionResult checkLogin(string username, [FromBody] JsonElement passwordJson)
        {
            _BLL = new BE_ConsilierInteligent.Application.Services.Impl.AuthBLL(_config);
            return _BLL.CheckLogin(username, passwordJson);

        }
    }
}

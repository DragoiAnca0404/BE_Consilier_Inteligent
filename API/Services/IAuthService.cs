using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace BE_ConsilierInteligent.Application.Services
{
    public interface IAuthService
    {
        IActionResult CheckLogin(string username, JsonElement passwordJson);

    }
}

using BE_ConsilierInteligent.Application.Services.Impl;
using BE_ConsilierInteligent.DataAccess.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace BE_ConsilierInteligent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaportHollandController : ControllerBase
    {
        private RaportPersonalitateHollandBLL _BLL;

        private readonly ConsilierContext _context;

        public RaportHollandController()
        {
            _BLL = new BE_ConsilierInteligent.Application.Services.Impl.RaportPersonalitateHollandBLL();

        }
        [HttpGet]
        public async Task<IActionResult> GetRaportHolland(string denumire_solutie)
        {
            var result = await _BLL.GetRaportHolland(denumire_solutie);
            return result;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using BE_ConsilierInteligent.DataAccess.Persistence;
using BE_ConsilierInteligent.Application.Services.Impl;


namespace BE_ConsilierInteligent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestHollandAntrenareController : ControllerBase
    {
        private TestHollandAntrenareBLL _BLL;
        private readonly ConsilierContext _context;


        public TestHollandAntrenareController()
        {
            _BLL = new BE_ConsilierInteligent.Application.Services.Impl.TestHollandAntrenareBLL();
        }


        [HttpGet("predict")]
        public async Task<IActionResult> Predict([FromQuery] float[] raspunsuri)
        {
            var result = await _BLL.Predict(raspunsuri);
            return result;
        }

       [HttpGet("metrici")]
        public async Task<IActionResult> GetMetrics()
        {
            var result = await _BLL.GetMetricsBLL();

            return result;
        }

    }
}

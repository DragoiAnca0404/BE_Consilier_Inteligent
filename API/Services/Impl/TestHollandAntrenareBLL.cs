using AutoMapper;
using Business_Logic_Layer;
using Microsoft.AspNetCore.Mvc;

namespace BE_ConsilierInteligent.Application.Services.Impl
{
    public class TestHollandAntrenareBLL : ControllerBase, ITestHollandAntrenareService
    {
        private readonly DataAccess.TestHollandAntrenareDAL _DAL;
        private readonly IMapper _mapper;

        public TestHollandAntrenareBLL()
        {
            _DAL = new DataAccess.TestHollandAntrenareDAL();
            var autoMapperConfiguration = new AutoMapperConfiguration();
            _mapper = autoMapperConfiguration.Configure();
        }


        public async Task<IActionResult> Predict([FromQuery] float[] raspunsuri)
        {
            if (raspunsuri == null || raspunsuri.Length != 12)
            {
                return BadRequest("Invalid input data");
            }

            var denumire_solutie = await _DAL.Predict(raspunsuri);

            return _mapper.Map<IActionResult>(denumire_solutie);

        }

        public async Task<IActionResult> GetMetricsBLL()
        {

            return await _DAL.GetMetrics();
        }
    }
}

using AutoMapper;
using Business_Logic_Layer;
using Microsoft.AspNetCore.Mvc;

namespace BE_ConsilierInteligent.Application.Services.Impl
{
    public class RaportPersonalitateHollandBLL : IRaportHollandService
    {
        private readonly DataAccess.RaportPersonalitateHollandDAL _DAL;
        private readonly IMapper _mapper;
        public RaportPersonalitateHollandBLL()
        {
            _DAL = new DataAccess.RaportPersonalitateHollandDAL();
            var autoMapperConfiguration = new AutoMapperConfiguration();
            _mapper = autoMapperConfiguration.Configure();
        }
        public async Task<IActionResult> GetRaportHolland(string denumire_solutie)
        {
            DataAccess.Entities.Solutie solutieEntity = _mapper.Map<Models.Solutie, DataAccess.Entities.Solutie>(new Models.Solutie { denumire_solutie = denumire_solutie });

            if (solutieEntity == null)
            {
                return null;
            }

            return await _DAL.GetRaportHolland(solutieEntity.denumire_solutie);
        }

    }
}

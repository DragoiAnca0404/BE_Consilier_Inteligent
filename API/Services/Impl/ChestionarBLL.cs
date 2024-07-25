using AutoMapper;
using BE_ConsilierInteligent.BLL.Utils;
using BE_ConsilierInteligent.DataAccess;
using Business_Logic_Layer;
using Microsoft.AspNetCore.Mvc;


namespace BE_ConsilierInteligent.Application.Services.Impl
{
    public class ChestionarBLL : IChestionarService
    {
        private readonly DataAccess.ChestionarDAL _DAL;
        private readonly IMapper _mapper;
        public ChestionarBLL()
        {
            _DAL = new DataAccess.ChestionarDAL();
            var autoMapperConfiguration = new AutoMapperConfiguration();
            _mapper = autoMapperConfiguration.Configure();
        }
        public async Task<IActionResult> GetAllTests()
        {
          /*  DataAccess.Entities.Utilizator userEntity = _mapper.Map<Models.Utilizator, DataAccess.Entities.Utilizator>(new Models.Utilizator { username = username });

            if (userEntity == null)
            {
                return null;
            }*/

            return await _DAL.GetAllTests();

        }

        public async Task<IActionResult> GetIntrebari(int id_chestionar)
        {
            DataAccess.Entities.Chestionar quizEntity = _mapper.Map<Models.Chestionar, DataAccess.Entities.Chestionar>(new Models.Chestionar { id_chestionar = id_chestionar });
            return await _DAL.GetIntrebari(quizEntity.id_chestionar);
        }

        public async Task<IActionResult> GetAllPasiuni()
        {
            return await _DAL.GetAllPasiuni();
        }
        public async Task<IActionResult> CreateChestionar(AddChestionarBLL chestionarDTO)
        {

            var addChestionar = new AddChestionar
            {
                DenumireTest = chestionarDTO.DenumireTest,
                username = chestionarDTO.username,
                Intrebari = chestionarDTO.Intrebari
            };

            return await _DAL.PostChestionar(addChestionar);
        }




    }
}
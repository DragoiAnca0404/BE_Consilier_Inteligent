using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AutoMapper;
using BE_ConsilierInteligent.Application.Mapping.Config;

namespace BE_ConsilierInteligent.Application.Services.Impl
{
    public class AuthBLL : ControllerBase, IAuthService
    {
        private readonly DataAccess.AuthDAL _DAL;
        private readonly IMapper _mapper;

        public AuthBLL(IConfiguration config)
        {
            _DAL = new DataAccess.AuthDAL(config);
            var autoMapperConfiguration = new AutoMapperConfig();
            _mapper = autoMapperConfiguration.Configure();
        }

        public IActionResult CheckLogin(string username, [FromBody] JsonElement passwordJson)
        {

            var userEntity = _mapper.Map<DataAccess.Entities.Utilizator>(new Models.Utilizator
            {
                username = username,
                parola = passwordJson.GetProperty("password").GetString()
            });

            var result = _DAL.checkLogin(userEntity.username, userEntity.parola);

            return result;
        }
    }
}

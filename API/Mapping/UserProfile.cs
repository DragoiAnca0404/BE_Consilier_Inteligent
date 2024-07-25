using AutoMapper;

namespace BE_ConsilierInteligent.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Configurare automata
            CreateMap<Models.Utilizator, BE_ConsilierInteligent.DataAccess.Entities.Utilizator>();
            CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Utilizator, Models.Utilizator>();
        }

    }
}

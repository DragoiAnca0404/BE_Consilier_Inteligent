using AutoMapper;

namespace Business_Logic_Layer
{
    public class AutoMapperConfiguration 
    {
        public IMapper Configure()
        {
            //Configurare manuala
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Consilier, Models.Consilier>();
                cfg.CreateMap<Models.Consilier, BE_ConsilierInteligent.DataAccess.Entities.Consilier>();

                cfg.CreateMap<Models.Utilizator, BE_ConsilierInteligent.DataAccess.Entities.Utilizator>();
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Utilizator, Models.Utilizator>();

                cfg.CreateMap<Models.Elev, BE_ConsilierInteligent.DataAccess.Entities.Elev>();
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Elev, Models.Elev>();


                cfg.CreateMap<Models.Chestionar, BE_ConsilierInteligent.DataAccess.Entities.Chestionar>();
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Chestionar, Models.Chestionar>();

                cfg.CreateMap<Models.Solutii_Training, BE_ConsilierInteligent.DataAccess.Entities.Solutii_Training>();
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Solutii_Training, Models.Solutii_Training>();

                cfg.CreateMap<Models.Solutie, BE_ConsilierInteligent.DataAccess.Entities.Solutie>();
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Solutie, Models.Solutie>();

                cfg.CreateMap<Models.Intrebare, BE_ConsilierInteligent.DataAccess.Entities.Intrebare>();
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Intrebare, Models.Intrebare>();

                cfg.CreateMap<Models.Raspuns, BE_ConsilierInteligent.DataAccess.Entities.Raspuns>();
                cfg.CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Raspuns, Models.Raspuns>();
            });

            return config.CreateMapper();
        }
    }
}
using AutoMapper;

namespace BE_ConsilierInteligent.Application.Mapping.Config
{
    public class AutoMapperConfig
    {
        public  IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(UserProfile));
                cfg.AddProfile(typeof(RaportProfile));
            });

            return config.CreateMapper();
        }
    }
}

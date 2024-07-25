using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_ConsilierInteligent.Application.Mapping
{
    public class RaportProfile:Profile
    {
        public RaportProfile()
        {
            //Configurare automata
            CreateMap<Models.Solutie, BE_ConsilierInteligent.DataAccess.Entities.Solutie>();
            CreateMap<BE_ConsilierInteligent.DataAccess.Entities.Solutie, Models.Solutie>();
        }
    }
}

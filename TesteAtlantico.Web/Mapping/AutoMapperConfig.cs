using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAtlantico.Domain.Entities;
using TesteAtlantico.Web.ViewModels;

namespace TesteAtlantico.Web.Mapping
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMapping()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
                cfg.CreateMap<List<UsuarioViewModel>,List<Usuario>>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();

            return mapper;
        }

    }
}

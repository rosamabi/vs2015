using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vs2015.Models;
using vs2015.ViewModels;

namespace vs2015
{
    public class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UsuarioViewModel, Usuario>();
            });

            IMapper mapper = config.CreateMapper();
            var source = new UsuarioViewModel();
            var dest = mapper.Map<UsuarioViewModel, Usuario>(source);
        }
    }
}
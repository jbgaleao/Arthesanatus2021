using System;
using System.Linq;
using System.Reflection;

using Arthesanatus2021.AppMvc.ViewModels;
using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Revistas;

using AutoMapper;

namespace Arthesanatus2021.AppMvc.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }


    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Revista, RevistaViewModel>().ReverseMap();
            CreateMap<Receita, ReceitaViewModel>().ReverseMap();
            CreateMap<InformacoesReceita, InformacoesReceitaViewModel>().ReverseMap();
        }
    }
}
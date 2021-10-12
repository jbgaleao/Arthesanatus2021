

using System;
using System.Reflection;
using System.Web.Mvc;

using Arthesanatus2021.Business.Core.Notificacoes;
using Arthesanatus2021.Business.Models.Receitas;
using Arthesanatus2021.Business.Models.Receitas.Services;
using Arthesanatus2021.Business.Models.Revistas;
using Arthesanatus2021.Business.Models.Revistas.Services;
using Arthesanatus2021.Infra.Data.Context;
using Arthesanatus2021.Infra.Data.Repository;

using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Arthesanatus2021.AppMvc.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void RegisterDIContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            InitializeContainer(container);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            container.Register<Arthes2021Context>(Lifestyle.Scoped);

            container.Register<IReceitaRepository, ReceitaRepository>(Lifestyle.Scoped);
            container.Register<IReceitaService, ReceitaService>(Lifestyle.Scoped);
            container.Register<IRevistaRepository, RevistaRepository>(Lifestyle.Scoped);
            container.Register<IRevistaService, RevistaService>(Lifestyle.Scoped);
            container.Register<IInformacoesReceitaRepository, InformacoesReceitaRepository>(Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration()
                                                                .CreateMapper(container
                                                                .GetInstance));
        }
    }
}
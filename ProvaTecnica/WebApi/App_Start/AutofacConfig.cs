using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ProvaTecnica.IRepository;
using ProvaTecnica.IService;
using ProvaTecnica.Repository;
using ProvaTecnica.Service;

namespace ProvaTecnica.WebApi.App_Start
{
    /// <summary>
    /// Represent Autofac configuration.
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Configured instance of <see cref="IContainer"/>
        /// <remarks><see cref="AutofacConfig.Configure"/> must be called before trying to get Container instance.</remarks>
        /// </summary>
        public static IContainer Container;

        /// <summary>
        /// Initializes and configures instance of <see cref="IContainer"/>.
        /// </summary>
        /// <param name="configuration"></param>
        public static void Configure(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Serviços unicos por requisição
            builder.RegisterType<TecnologiaService>().As<ITecnologiaService>().InstancePerRequest();
            builder.RegisterType<OcupacaoService>().As<IOcupacaoService>().InstancePerRequest();
            builder.RegisterType<CandidatoService>().As<ICandidatoService>().InstancePerRequest();
            builder.RegisterType<SelecaoService>().As<ISelecaoService>().InstancePerRequest();

            // Instancias unicas da aplicação
            builder.Register(c => new TecnologiaRepository()).As<ITecnologiaRepository>().SingleInstance();
            builder.Register(c => new OcupacaoRepository()).As<IOcupacaoRepository>().SingleInstance();
            builder.Register(c => new CandidatoRepository()).As<ICandidatoRepository>().SingleInstance();
            builder.Register(c => new SelecaoRepository()).As<ISelecaoRepository>().SingleInstance();

            Container = builder.Build();

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}
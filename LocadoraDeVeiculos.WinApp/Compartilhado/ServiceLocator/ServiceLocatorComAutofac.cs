using LocadoraDeVeiculos.WinApp.GrupoVeiculos;
using LocadoraDeVeiculos.WinApp.ModuloCliente;
using LocadoraDeVeiculos.WinApp.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.WinApp.ModuloTaxa;
using LocadoraDeVeiculos.WinApp.ModuloVeiculo;
using LocadoraVeiculos.Aplicacao.ModuloCliente;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using LocadoraVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraVeiculos.Aplicacao.ModuloGrupoVeiculos;
using LocadoraVeiculos.Aplicacao.ModuloPlanoDeCobranca;
using LocadoraVeiculos.Aplicacao.ModuloTaxa;
using LocadoraVeiculos.Aplicacao.ModuloVeiculo;
using Autofac;
using LocadoraVeiculos.Infra.Orm;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Orm.ModuloOrm;
using LocadoraVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.WinApp.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao;
using LocadoraVeiculos.Aplicacao.ModuloDevolucao;
using LocadoraDeVeiculos.WinApp.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Config;
using LocadoraDeVeiculos.Infra.Pdf.ModuloLocacao;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();

        /*    builder.Register((x) => new ConfiguracaoAplicacaoLocadora().ConnectionStrings)
               .As<ConnectionStrings>()
               .SingleInstance(); //Singleton

            builder.RegisterType<ConfiguracaoAplicacaoLocadora>()
                .SingleInstance(); //Singleton
        */

            builder.RegisterType<ConfiguracaoAplicacaoLocadora>()
                .SingleInstance();

            builder.RegisterType<LocadoraDeVeiculosDbContext>().As<IContextoPersistencia>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RepositorioClienteOrm>().AsSelf();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculosOrm>().AsSelf();
            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculos>().AsSelf();

            builder.RegisterType<RepositorioFuncionarioOrm>().AsSelf();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutorOrm>().AsSelf();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioTaxaOrm>().AsSelf();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();
           
            builder.RegisterType<RepositorioPlanoCobrancaOrm>().AsSelf();
            builder.RegisterType<ServicoPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();             
            
            builder.RegisterType<RepositorioVeiculoOrm>().AsSelf();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<RepositorioLocacaoOrm>().AsSelf();
            builder.RegisterType<ServicoLocacao>().AsSelf();
            builder.RegisterType<ControladorLocacao>().AsSelf();

            builder.RegisterType<RepositorioDevolucaoOrm>().AsSelf();
            builder.RegisterType<ServicoDevolucao>().AsSelf();
            builder.RegisterType<ControladorDevolucao>().AsSelf();

            builder.RegisterType<GeradorRelatorioLocacaoItextSharp>().AsSelf();



            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}

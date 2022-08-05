using LocadoraDeVeiculos.Infra.ModuloCliente;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using LocadoraDeVeiculos.Infra.ModuloVeiculo;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Infra.Pdf.ITextSharp.ModuloLocacao;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public class ServiceLocatorComAutofac : IServiceLocator
    {
        private readonly IContainer container;

        public ServiceLocatorComAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RepositorioCliente>().AsSelf();
            builder.RegisterType<ServicoCliente>().AsSelf();
            builder.RegisterType<ControladorCliente>().AsSelf();

            builder.RegisterType<RepositorioGrupoVeiculos>().AsSelf();
            builder.RegisterType<ServicoGrupoVeiculos>().AsSelf();
            builder.RegisterType<ControladorGrupoVeiculos>().AsSelf();

            builder.RegisterType<RepositorioFuncionario>().AsSelf();
            builder.RegisterType<ServicoFuncionario>().AsSelf();
            builder.RegisterType<ControladorFuncionario>().AsSelf();

            builder.RegisterType<RepositorioCondutor>().AsSelf();
            builder.RegisterType<ServicoCondutor>().AsSelf();
            builder.RegisterType<ControladorCondutor>().AsSelf();

            builder.RegisterType<RepositorioTaxa>().AsSelf();
            builder.RegisterType<ServicoTaxa>().AsSelf();
            builder.RegisterType<ControladorTaxa>().AsSelf();
           
            builder.RegisterType<RepositorioPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ServicoPlanoDeCobranca>().AsSelf();
            builder.RegisterType<ControladorPlanoDeCobranca>().AsSelf();             
            
            builder.RegisterType<RepositorioVeiculo>().AsSelf();
            builder.RegisterType<ServicoVeiculo>().AsSelf();
            builder.RegisterType<ControladorVeiculo>().AsSelf();

            builder.RegisterType<GeradorRelatorioLocacaoItextSharp>().AsSelf();



            container = builder.Build();
        }

        public T Get<T>() where T : ControladorBase
        {
            return container.Resolve<T>();
        }
    }
}

using LocadoraDeVeiculos.Infra.Orm;
using LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator;
using LocadoraVeiculos.Infra.Logging;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MigradorBancoDadosLocadoraDeVeiculos.AtualizarBancoDados();

            ConfiguracaoLogsLocadora.ConfigurarEscritaLogs();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var serviceLocatorAutofac = new ServiceLocatorComAutofac();

            Application.Run(new TelaInicial(new ServiceLocatorComAutofac()));
        }
    }
}

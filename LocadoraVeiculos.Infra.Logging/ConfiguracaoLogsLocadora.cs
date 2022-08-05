using LocadoraDeVeiculos.Infra.Config;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Infra.Logging
{
    public class ConfiguracaoLogsLocadora
    {
        public static void ConfigurarEscritaLogs()
        {
            var config = new ConfiguracaoAplicacaoLocadora();

            var diretorioSaida = config.ConfiguracaoLogs.DiretorioSaida;
           
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.File(diretorioSaida + "/log.txt" ,
               rollingInterval: RollingInterval.Day,
               outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
               .CreateLogger();

        }
        
    }
}

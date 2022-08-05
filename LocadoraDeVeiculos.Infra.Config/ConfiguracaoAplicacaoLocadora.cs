using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LocadoraDeVeiculos.Infra.Config
{
    public class ConfiguracaoAplicacaoLocadora
    {
        public ConfiguracaoAplicacaoLocadora()
        {
            IConfiguration configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("ConfiguracaoAplicacao.json")
             .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            ConnectionStrings = new ConnectionStrings { SqlServer = connectionString };

            var diretorioSaida = configuracao
                .GetSection("ConfiguracaoLogs")
                .GetSection("DiretorioSaida").Value;

            ConfiguracaoLogs = new ConfiguracaoLogs { DiretorioSaida = diretorioSaida };
        }
        public ConfiguracaoLogs ConfiguracaoLogs { get; set; }

        public ConnectionStrings ConnectionStrings { get; set; }

    }
        public class ConfiguracaoLogs
        {
             public string DiretorioSaida { get; set; }
        }

        public class ConnectionStrings
        {
             public string SqlServer { get; set; }
        }
    
}

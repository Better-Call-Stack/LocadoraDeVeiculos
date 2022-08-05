using LocadoraDeVeiculos.Infra.Config;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm
{
    public class LocadoraDeVeiculosDbContextFactory : IDesignTimeDbContextFactory<LocadoraDeVeiculosDbContext>
    {
        public LocadoraDeVeiculosDbContext CreateDbContext(string[] args)
        {
            var config = new ConfiguracaoAplicacaoLocadora();

            return new LocadoraDeVeiculosDbContext(config);
        }
    }
}

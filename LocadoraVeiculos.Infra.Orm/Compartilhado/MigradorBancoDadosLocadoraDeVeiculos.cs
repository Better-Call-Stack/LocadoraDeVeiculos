using LocadoraDeVeiculos.Infra.Config;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm
{
    public static class MigradorBancoDadosLocadoraDeVeiculos
    {
        public static void AtualizarBancoDados()
        {
            var config = new ConfiguracaoAplicacaoLocadora();

            var db = new LocadoraDeVeiculosDbContext(config);

            var migracoesPendentes = db.Database.GetPendingMigrations();

            if (migracoesPendentes.Count() > 0)
                db.Database.Migrate();
        }
    }
}

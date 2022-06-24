using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoDeVeiculos>
    {
        public override void ConfigurarParametros(GrupoDeVeiculos grupoDeVeiculos, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", grupoDeVeiculos.Id);
            comando.Parameters.AddWithValue("NOME", grupoDeVeiculos.Nome);
            comando.Parameters.AddWithValue("VALORPLANODIARIO", grupoDeVeiculos.ValorPlanoDiario);
            comando.Parameters.AddWithValue("VALORDIARIOKMCONTROLADO", grupoDeVeiculos.ValorDiariaKmControlado);
            comando.Parameters.AddWithValue("VALORDIARIOKMLIVRE", grupoDeVeiculos.ValorDiarioKmLivre);
        }

        public override GrupoDeVeiculos ConverterRegistro(SqlDataReader leitorGrupoDeVeiculos)
        {
            var id = Convert.ToInt32(leitorGrupoDeVeiculos["ID"]);
            var nome = Convert.ToString(leitorGrupoDeVeiculos["NOME"]);
            var valorPlanoDiario = Convert.ToDecimal(leitorGrupoDeVeiculos["VALORPLANODIARIO"]);
            var valorDiariaKmControlado = Convert.ToDecimal(leitorGrupoDeVeiculos["VALORDIARIOKMCONTROLADO"]);
            var valorDiarioKmLivre = Convert.ToDecimal(leitorGrupoDeVeiculos["VALORDIARIOKMLIVRE"]);

            GrupoDeVeiculos grupoDeVeiculos = new GrupoDeVeiculos();
            grupoDeVeiculos.Id = id;
            grupoDeVeiculos.Nome = nome;
            grupoDeVeiculos.ValorPlanoDiario = valorPlanoDiario;
            grupoDeVeiculos.ValorDiariaKmControlado = valorDiariaKmControlado;
            grupoDeVeiculos.ValorDiarioKmLivre = valorDiarioKmLivre;

            return grupoDeVeiculos;
        }
    }
}

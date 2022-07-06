using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class MapeadorPlanoDeCobranca : MapeadorBase<PlanoDeCobranca>
    {
        public override void ConfigurarParametros(PlanoDeCobranca planoDeCobranca, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", planoDeCobranca.Id);
            comando.Parameters.AddWithValue("TXTVALORKMRODADO_PLANODIARIO", planoDeCobranca.txtValorKmRodado_PlanoDiario);
            comando.Parameters.AddWithValue("TXTVALORPORDIA_PLANODIARIO", planoDeCobranca.txtValorPorDia_PlanoDiario);
            comando.Parameters.AddWithValue("TXTVALORKMRODADO_PLANOKMCONTROLADO", planoDeCobranca.txtValorKmRodado_PlanoKmControlado);
            comando.Parameters.AddWithValue("TXTKMLIVREINCLUSO_PLANOKMCONTROLADO", planoDeCobranca.txtKmLivreIncluso_PlanoKmControlado);
            comando.Parameters.AddWithValue("TXTVALORPORDIA_PLANOKMCONTROLADO", planoDeCobranca.txtValorPorDia_PlanoKmControlado);
            comando.Parameters.AddWithValue("TXTVALORPORDIA_PLANOKMLIVRE", planoDeCobranca.txtValorPorDia_PlanoKmLivre);
        }

        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorPlanoDeCobranca)
        {
            var id = Convert.ToInt32(leitorPlanoDeCobranca["ID"]);
            var valorKmRodado_PlanoDiario = Convert.ToDecimal(leitorPlanoDeCobranca["TXTVALORKMRODADO_PLANODIARIO"]);
            var valorPorDia_PlanoDiario = Convert.ToDecimal(leitorPlanoDeCobranca["TXTVALORPORDIA_PLANODIARIO"]);
            var valorKmRodado_PlanoKmControlado = Convert.ToDecimal(leitorPlanoDeCobranca["TXTVALORKMRODADO_PLANOKMCONTROLADO"]);
            var kmLivreIncluso_PlanoKmControlado = Convert.ToDecimal(leitorPlanoDeCobranca["TXTKMLIVREINCLUSO_PLANOKMCONTROLADO"]);
            var valorPorDia_PlanoKmControlado = Convert.ToDecimal(leitorPlanoDeCobranca["TXTVALORPORDIA_PLANOKMCONTROLADO"]);
            var valorPorDia_PlanoKmLivre = Convert.ToDecimal(leitorPlanoDeCobranca["TXTVALORPORDIA_PLANOKMLIVRE"]);

            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca();
            planoDeCobranca.Id = id;
            planoDeCobranca.txtValorKmRodado_PlanoDiario = valorKmRodado_PlanoDiario;
            planoDeCobranca.txtValorPorDia_PlanoDiario = valorPorDia_PlanoDiario;
            planoDeCobranca.txtValorKmRodado_PlanoKmControlado = valorKmRodado_PlanoKmControlado;
            planoDeCobranca.txtKmLivreIncluso_PlanoKmControlado = kmLivreIncluso_PlanoKmControlado;
            planoDeCobranca.txtValorPorDia_PlanoKmControlado = valorPorDia_PlanoKmControlado;
            planoDeCobranca.txtValorPorDia_PlanoKmLivre = valorPorDia_PlanoKmLivre;

            return planoDeCobranca;
        }
    }
}

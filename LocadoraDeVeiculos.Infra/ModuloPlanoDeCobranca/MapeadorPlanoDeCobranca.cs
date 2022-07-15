using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
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
            comando.Parameters.AddWithValue("VALORKMRODADO_PLANODIARIO", planoDeCobranca.ValorKmRodado_PlanoDiario);
            comando.Parameters.AddWithValue("VALORPORDIA_PLANODIARIO", planoDeCobranca.ValorPorDia_PlanoDiario);
            comando.Parameters.AddWithValue("VALORKMRODADO_PLANOKMCONTROLADO", planoDeCobranca.ValorKmRodado_PlanoKmControlado);
            comando.Parameters.AddWithValue("KMLIVREINCLUSO_PLANOKMCONTROLADO", planoDeCobranca.KmLivreIncluso_PlanoKmControlado);
            comando.Parameters.AddWithValue("VALORPORDIA_PLANOKMCONTROLADO", planoDeCobranca.ValorPorDia_PlanoKmControlado);
            comando.Parameters.AddWithValue("VALORPORDIA_PLANOKMLIVRE", planoDeCobranca.ValorPorDia_PlanoKmLivre);
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", planoDeCobranca.GrupoDeVeiculos.Id);

        }

        public override PlanoDeCobranca ConverterRegistro(SqlDataReader leitorPlanoDeCobranca)
        {
            var id = Guid.Parse(leitorPlanoDeCobranca["PC_ID"].ToString());
            var valorKmRodado_PlanoDiario = Convert.ToDecimal(leitorPlanoDeCobranca["PC_VALORKMRODADO_PLANODIARIO"]);
            var valorPorDia_PlanoDiario = Convert.ToDecimal(leitorPlanoDeCobranca["PC_VALORPORDIA_PLANODIARIO"]);
            var valorKmRodado_PlanoKmControlado = Convert.ToDecimal(leitorPlanoDeCobranca["PC_VALORKMRODADO_PLANOKMCONTROLADO"]);
            var kmLivreIncluso_PlanoKmControlado = Convert.ToDecimal(leitorPlanoDeCobranca["PC_KMLIVREINCLUSO_PLANOKMCONTROLADO"]);
            var valorPorDia_PlanoKmControlado = Convert.ToDecimal(leitorPlanoDeCobranca["PC_VALORPORDIA_PLANOKMCONTROLADO"]);
            var valorPorDia_PlanoKmLivre = Convert.ToDecimal(leitorPlanoDeCobranca["PC_VALORPORDIA_PLANOKMLIVRE"]);
            
            PlanoDeCobranca planoDeCobranca = new PlanoDeCobranca();
            planoDeCobranca.Id = id;
            planoDeCobranca.ValorKmRodado_PlanoDiario = valorKmRodado_PlanoDiario;
            planoDeCobranca.ValorPorDia_PlanoDiario = valorPorDia_PlanoDiario;
            planoDeCobranca.ValorKmRodado_PlanoKmControlado = valorKmRodado_PlanoKmControlado;
            planoDeCobranca.KmLivreIncluso_PlanoKmControlado = kmLivreIncluso_PlanoKmControlado;
            planoDeCobranca.ValorPorDia_PlanoKmControlado = valorPorDia_PlanoKmControlado;
            planoDeCobranca.ValorPorDia_PlanoKmLivre = valorPorDia_PlanoKmLivre;

            planoDeCobranca.GrupoDeVeiculos = new MapeadorGrupoVeiculos().ConverterRegistro(leitorPlanoDeCobranca);

            return planoDeCobranca;
        }
    }
}

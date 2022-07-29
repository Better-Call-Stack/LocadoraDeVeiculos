using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloTaxa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloDevolucao
{
    public class MapeadorDevolucao : MapeadorBase<Devolucao>
    {
        public override void ConfigurarParametros(Devolucao registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("VALORGASOLINA", registro.ValorGasolina);
            comando.Parameters.AddWithValue("QUILOMETRAGEM", registro.Quilometragem);
            comando.Parameters.AddWithValue("DATADEVOLUCAO", registro.DataDevolucao);
            comando.Parameters.AddWithValue("VOLUMETANQUE", registro.VolumeTanque);
            comando.Parameters.AddWithValue("LOCACAO_ID", registro.Locacao.Id);
            comando.Parameters.AddWithValue("TAXA_ID", registro.Taxa.Id); 
        }

        public override Devolucao ConverterRegistro(SqlDataReader leitorDevolucao)
        {
            var id = Guid.Parse(leitorDevolucao["DV_ID"].ToString());
            var valorGasolina = Convert.ToDecimal(leitorDevolucao["DV_VALORGASOLINA"]);
            var quilometragem = Convert.ToDecimal(leitorDevolucao["DV_QUILOMETRAGEM"]);
            var dataDevolucao = Convert.ToDateTime(leitorDevolucao["DV_DATADEVOLUCAO"]);
            var volumeTanque = (VolumeTanque)leitorDevolucao["DV_VOLUMETANQUE"];

            Devolucao devolucao = new Devolucao();
            devolucao.Id = id;
            devolucao.ValorGasolina = valorGasolina;
            devolucao.Quilometragem = quilometragem;
            devolucao.DataDevolucao = dataDevolucao;
            devolucao.VolumeTanque = volumeTanque;

            //depois descomentar
            //devolucao.Locacao = new MapeadorLocacao().ConverterRegistro(leitorDevolucao);
            devolucao.Taxa = new MapeadorTaxa().ConverterRegistro(leitorDevolucao);

            return devolucao;
        }
    }
}

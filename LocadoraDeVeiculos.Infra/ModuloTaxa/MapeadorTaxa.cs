using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloTaxa
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa taxa, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", taxa.Id);
            comando.Parameters.AddWithValue("NOME", taxa.Nome);
            comando.Parameters.AddWithValue("VALOR", taxa.Valor);
            comando.Parameters.AddWithValue("TIPOCOBRANCA", taxa.Tipo);
        }

        public override Taxa ConverterRegistro(SqlDataReader leitorTaxa)
        {
            var id = Convert.ToInt32(leitorTaxa["ID"]);
            var nome = Convert.ToString(leitorTaxa["NOME"]);
            var valor = Convert.ToDecimal(leitorTaxa["VALOR"]);
            var tipoCobranca =(TipoCalculoTaxa)(leitorTaxa["TIPOCOBRANCA"]);


            Taxa taxa = new Taxa();
            taxa.Id = id;
            taxa.Nome = nome;
            taxa.Valor = valor;
            taxa.Tipo = tipoCobranca;
            



            return taxa;
        }
    }
}

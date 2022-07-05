using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            throw new NotImplementedException();
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            throw new NotImplementedException();
        }
    }
}

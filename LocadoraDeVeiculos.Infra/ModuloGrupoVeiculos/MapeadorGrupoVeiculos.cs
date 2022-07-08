using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos
{
    public class MapeadorGrupoVeiculos : MapeadorBase<GrupoDeVeiculos>
    {
        public override void ConfigurarParametros(GrupoDeVeiculos grupoDeVeiculos, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", grupoDeVeiculos.Id);
            comando.Parameters.AddWithValue("NOME", grupoDeVeiculos.Nome);

        }

        public override GrupoDeVeiculos ConverterRegistro(SqlDataReader leitorGrupoDeVeiculos)
        {
            var id = Convert.ToInt32(leitorGrupoDeVeiculos["ID"]);
            var nome = Convert.ToString(leitorGrupoDeVeiculos["NOME"]);


            GrupoDeVeiculos grupoDeVeiculos = new GrupoDeVeiculos();
            grupoDeVeiculos.Id = id;
            grupoDeVeiculos.Nome = nome;


            return grupoDeVeiculos;
        }
    }
}

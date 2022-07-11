using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
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
        MapeadorGrupoVeiculos mapeadorGrupoDeVeiculos;
        public MapeadorVeiculo()
        {
            this.mapeadorGrupoDeVeiculos = new MapeadorGrupoVeiculos();
        }
        public override void ConfigurarParametros(Veiculo veiculo, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", veiculo.Id);
            comando.Parameters.AddWithValue("MODELO", veiculo.Modelo);
            comando.Parameters.AddWithValue("FABRICANTE", veiculo.Fabricante);
            comando.Parameters.AddWithValue("PLACA", veiculo.Placa);
            comando.Parameters.AddWithValue("COR", veiculo.Cor);
            comando.Parameters.AddWithValue("TIPOCOMBUSTIVEL", veiculo.TipoCombustivel);
            comando.Parameters.AddWithValue("CAPACIDADEDOTANQUE", veiculo.CapacidadeTanque);
            comando.Parameters.AddWithValue("ANO", veiculo.Ano);
            comando.Parameters.AddWithValue("KMPERCORRIDO", veiculo.KmPercorrido);
            comando.Parameters.AddWithValue("STATUSVEICULO", veiculo.StatusVeiculo);
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", veiculo.Grupo.Id);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorVeiculo)
        {
            var id = Convert.ToInt32(leitorVeiculo["ID"]);
            var modelo = Convert.ToString(leitorVeiculo["MODELO"]);
            var fabricante = Convert.ToString(leitorVeiculo["FABRICANTE"]);
            var placa = Convert.ToString(leitorVeiculo["PLACA"]);
            var cor = Convert.ToString(leitorVeiculo["COR"]);
            var tipoCombustivel = Convert.ToInt32(leitorVeiculo["TIPOCOMBUSTIVEL"]);
            var capacidadeDoTanque = Convert.ToDecimal(leitorVeiculo["CAPACIDADEDOTANQUE"]);
            var ano = Convert.ToInt32(leitorVeiculo["ANO"]);
            var kmpercorrido = Convert.ToInt32(leitorVeiculo["KMPERCORRIDO"]);
            var statusVeiculo = Convert.ToInt32(leitorVeiculo["STATUSVEICULO"]);
            var grupoveiculos_id = Convert.ToString(leitorVeiculo["GRUPOVEICULOS_ID"]);

            Veiculo veiculo = new Veiculo();
            veiculo.Id = id;
            veiculo.Modelo = modelo;
            veiculo.Fabricante = fabricante;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.TipoCombustivel = (TipoCombustivelEnum)tipoCombustivel;
            veiculo.CapacidadeTanque = capacidadeDoTanque;
            veiculo.Ano = ano;
            veiculo.KmPercorrido = kmpercorrido;
            veiculo.StatusVeiculo = (StatusVeiculoEnum)statusVeiculo;
            var veiculoGrupo = mapeadorGrupoDeVeiculos.ConverterRegistro(leitorVeiculo);

            return veiculo;
        }
    }
}

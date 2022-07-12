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
            var id = Convert.ToInt32(leitorVeiculo["VEICULO.ID"]);
            var modelo = Convert.ToString(leitorVeiculo["VEICULO.MODELO"]);
            var fabricante = Convert.ToString(leitorVeiculo["VEICULO.FABRICANTE"]);
            var placa = Convert.ToString(leitorVeiculo["VEICULO.PLACA"]);
            var cor = Convert.ToString(leitorVeiculo["VEICULO.COR"]);
            var tipoCombustivel = Convert.ToInt32(leitorVeiculo["VEICULO.TIPOCOMBUSTIVEL"]);
            var capacidadeDoTanque = Convert.ToDecimal(leitorVeiculo["VEICULO.CAPACIDADEDOTANQUE"]);
            var ano = Convert.ToInt32(leitorVeiculo["VEICULO.ANO"]);
            var kmpercorrido = Convert.ToInt32(leitorVeiculo["VEICULO.KMPERCORRIDO"]);
            var statusVeiculo = Convert.ToInt32(leitorVeiculo["VEICULO.STATUSVEICULO"]);
            

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
            veiculo.Grupo = new MapeadorGrupoVeiculos().ConverterRegistro(leitorVeiculo);

            return veiculo;
        }
    }
}

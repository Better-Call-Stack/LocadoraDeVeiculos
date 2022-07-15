using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos;
using System;
using System.Data.SqlClient;
using System.Text;

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
            comando.Parameters.AddWithValue("FOTOVEICULO", veiculo.FotoVeiculo);
            comando.Parameters.AddWithValue("GRUPOVEICULOS_ID", veiculo.Grupo.Id);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorVeiculo)
        {
            var id = Guid.Parse(leitorVeiculo["VEICULO_ID"].ToString());
            var modelo = Convert.ToString(leitorVeiculo["VEICULO_MODELO"]);
            var fabricante = Convert.ToString(leitorVeiculo["VEICULO_FABRICANTE"]);
            var placa = Convert.ToString(leitorVeiculo["VEICULO_PLACA"]);
            var cor = Convert.ToString(leitorVeiculo["VEICULO_COR"]);
            int tipoCombustivel = Convert.ToInt32(leitorVeiculo["VEICULO_TIPOCOMBUSTIVEL"]);
            var capacidadeDoTanque = Convert.ToDecimal(leitorVeiculo["VEICULO_CAPACIDADE"]);
            var ano = Convert.ToInt32(leitorVeiculo["VEICULO_ANO"]);
            var kmpercorrido = Convert.ToInt32(leitorVeiculo["VEICULO_KMPERCORRIDO"]);
            var statusVeiculo = Convert.ToInt32(leitorVeiculo["VEICULO_STATUS"]);
            byte[] fotoVeiculo = (byte[])leitorVeiculo["VEICULO_FOTO"];
            

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
            veiculo.FotoVeiculo = fotoVeiculo;
            veiculo.Grupo = new MapeadorGrupoVeiculos().ConverterRegistro(leitorVeiculo);

            return veiculo;
        }
    }
}

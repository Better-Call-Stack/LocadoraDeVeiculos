using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Veiculo()
        {
            Ano = 2022;
        }

        TipoCombustivelEnum tipoCombustivel;
        StatusVeiculoEnum statusVeiculo;

        public GrupoDeVeiculos Grupo { get; set; }

        public string Modelo { get; set; }

        public string Fabricante { get; set; }

        public string Placa { get; set; }

        public string Cor { get; set; }

        public TipoCombustivelEnum TipoCombustivel
        {
            get { return tipoCombustivel; }
            set
            {
                tipoCombustivel = value;
            }
        }

        public StatusVeiculoEnum StatusVeiculo
        {
            get { return statusVeiculo; }
            set
            {
                statusVeiculo = value;
            }
        }

        public decimal CapacidadeTanque { get; set; }

        public int Ano { get; set; }

        public int KmPercorrido { get; set; }

        public string FotoVeiculo { get; set; }


        public override void Atualizar(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public Veiculo Clonar()
        {
            return MemberwiseClone() as Veiculo;
        }
    }
}

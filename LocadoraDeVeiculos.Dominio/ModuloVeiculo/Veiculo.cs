using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Veiculo()
        {
            Ano = 2022;
            FotoVeiculo = default;
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

        public byte[] FotoVeiculo { get; set; }

        public Bitmap Imagem
        {
            get
            {
                if (FotoVeiculo != null)
                {

                    using (MemoryStream ms = new MemoryStream(FotoVeiculo))
                    {
                        return new Bitmap(ms);
                    }


                }
                return null;
            }
        }
        

        public override void Atualizar(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public Veiculo Clonar()
        {
            return MemberwiseClone() as Veiculo;
        }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   tipoCombustivel == veiculo.tipoCombustivel &&
                   statusVeiculo == veiculo.statusVeiculo &&
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(Grupo, veiculo.Grupo) &&
                   Modelo == veiculo.Modelo &&
                   Fabricante == veiculo.Fabricante &&
                   Placa == veiculo.Placa &&
                   Cor == veiculo.Cor &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   StatusVeiculo == veiculo.StatusVeiculo &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Ano == veiculo.Ano &&
                   KmPercorrido == veiculo.KmPercorrido &&
                   FotoVeiculo == veiculo.FotoVeiculo;
        }
    }
}

﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {

        TipoCombustivel tipoCombustivel;
        
        public GrupoDeVeiculos Grupo { get; set; }

        public string Modelo { get; set; }
        
        public string Marca { get; set; }
        
        public string Placa { get; set; }
        
        public string Cor { get; set; }

        public TipoCombustivel TipoCombustivel
        {
            get { return tipoCombustivel; }
            set
            {
                tipoCombustivel = value;

            }
        }

        public decimal CapacidadeTanque { get; set; }
        
        public int Ano { get; set; }
        
        public int KmPercorrido { get; set; }



        public override void Atualizar(Veiculo registro)
        {
            throw new NotImplementedException();
        }
    }
}
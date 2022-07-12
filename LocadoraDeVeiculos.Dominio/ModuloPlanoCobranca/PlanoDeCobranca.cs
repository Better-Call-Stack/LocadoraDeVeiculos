using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoDeCobranca : EntidadeBase<PlanoDeCobranca>
    {
        public string Nome { get; set; }

        public GrupoDeVeiculos GrupoDeVeiculos { get; set; }

        public decimal ValorKmRodado { get; set; }

        public decimal ValorDaDiaria { get; set; }

        public decimal KmLivreIncluso { get; set; }


        public override void Atualizar(PlanoDeCobranca registro)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is PlanoDeCobranca cobranca &&
                   Id == cobranca.Id &&
                   Nome == cobranca.Nome &&
                   EqualityComparer<GrupoDeVeiculos>.Default.Equals(GrupoDeVeiculos, cobranca.GrupoDeVeiculos) &&
                   ValorKmRodado == cobranca.ValorKmRodado &&
                   ValorDaDiaria == cobranca.ValorDaDiaria &&
                   KmLivreIncluso == cobranca.KmLivreIncluso;
        }
    }
}


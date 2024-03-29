﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    [Serializable]
    public class GrupoDeVeiculos : EntidadeBase<GrupoDeVeiculos>
    {
        public GrupoDeVeiculos()
        {

        }

        public GrupoDeVeiculos(string nome)
        {
            Nome = nome;

        }
        public string Nome { get; set; }


        public override string ToString()
        {
            return $"Nome: {Nome}";
        }

        public GrupoDeVeiculos Clonar()
        {
            return MemberwiseClone() as GrupoDeVeiculos;
        }

        public override void Atualizar(GrupoDeVeiculos registro)
        {
            Nome = registro.Nome;

        }

        public override bool Equals(object obj)
        {
            return obj is GrupoDeVeiculos controladorGrupoVeiculos &&
                   Nome == controladorGrupoVeiculos.Nome;

        }

    }
}

﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string CNH { get; set; }

        public DateTime ValidadeCNH { get; set; }

        public string Cidade { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public Cliente Cliente { get; set; }

        public override void Atualizar(Condutor registro)
        {
            throw new NotImplementedException();
        }
    }
}

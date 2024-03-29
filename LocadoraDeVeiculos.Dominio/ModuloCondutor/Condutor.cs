﻿using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;

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

        public Guid ClienteId { get; set; }

        public override void Atualizar(Condutor registro)
        {
            throw new NotImplementedException();
        }

        public Condutor Clonar()
        {
            return MemberwiseClone() as Condutor;
        }

        public override bool Equals(object obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   CPF == condutor.CPF &&
                   CNH == condutor.CNH &&
                   ValidadeCNH == condutor.ValidadeCNH &&
                   Cidade == condutor.Cidade &&
                   Endereco == condutor.Endereco &&
                   Telefone == condutor.Telefone &&
                   Email == condutor.Email &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente);
        }
    }
}

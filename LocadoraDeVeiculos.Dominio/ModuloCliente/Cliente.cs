using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        public Cliente()
        {
            CPF = "";
            CNPJ = "";
        }



        private TipoPessoa tipoPessoa;

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        public string Cidade { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public TipoPessoa TipoPessoa
        {
            get { return tipoPessoa; }
            set
            {
                tipoPessoa = value;

            }
        }


        public Cliente Clonar()
        {
            return MemberwiseClone() as Cliente;
        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   tipoPessoa == cliente.tipoPessoa &&
                   Nome == cliente.Nome &&
                   CPF == cliente.CPF &&
                   CNPJ == cliente.CNPJ &&
                   Cidade == cliente.Cidade &&
                   Endereco == cliente.Endereco &&
                   Telefone == cliente.Telefone &&
                   Email == cliente.Email &&
                   TipoPessoa == cliente.TipoPessoa;
        }

        public override void Atualizar(Cliente registro)
        {
            throw new NotImplementedException();
        }
    }
}

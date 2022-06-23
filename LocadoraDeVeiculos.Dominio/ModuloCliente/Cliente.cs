using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase<Cliente>
    {
        private TipoPessoa tipoPessoa;

        public string Nome
        {
            get => default;
            set
            {
            }
        }

        public string CPF
        {
            get => default;
            set
            {
            }
        }

        public string CNPJ
        {
            get => default;
            set
            {
            }
        }

        public string Cidade { get; set; }

        public string Endereco
        {
            get => default;
            set
            {
            }
        }

        public string Telefone
        {
            get => default;
            set
            {
            }
        }

        public string CNH
        {
            get => default;
            set
            {
            }
        }

        public string Email { get; set; }

        public TipoPessoa TipoPessoa
        {
            get { return tipoPessoa; }
            set
            {
                tipoPessoa = value;

                }
            }
        
    }
}

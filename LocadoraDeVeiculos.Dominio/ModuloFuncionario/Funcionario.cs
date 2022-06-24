using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public int Salario
        {
            get => default;
            set
            {
            }
        }

        public int Nome
        {
            get => default;
            set
            {
            }
        }

        public int DataDeAdmissao
        {
            get => default;
            set
            {
            }
        }

        public int Login
        {
            get => default;
            set
            {
            }
        }

        public int Senha
        {
            get => default;
            set
            {
            }
        }

        public int TipoPerfil
        {
            get => default;
            set
            {
            }
        }

        public override void Atualizar(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}

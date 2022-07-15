using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {

        public Funcionario()
        {
            DataDeAdmissao = DateTime.Now;
        }

        private PerfilEnum perfil;
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public decimal Salario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public PerfilEnum Perfil
        {
            get { return perfil; }
            set
            {
                perfil = value;

            }
        }

        public Funcionario Clonar()
        {
            return MemberwiseClone() as Funcionario;
        }

        public override void Atualizar(Funcionario registro)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario&&
                   Id==funcionario.Id&&
                   perfil==funcionario.perfil&&
                   Nome==funcionario.Nome&&
                   CPF==funcionario.CPF&&
                   DataDeAdmissao==funcionario.DataDeAdmissao&&
                   Salario==funcionario.Salario&&
                   Login==funcionario.Login&&
                   Senha==funcionario.Senha&&
                   Perfil==funcionario.Perfil;
        }
    }
}

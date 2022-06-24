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

        public string Nome { get; set; }
        public DateTime DataDeAdmissao { get; set; }
        public decimal Salario { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public override void Atualizar(Funcionario registro)
        {
            throw new NotImplementedException();
        }
    }
}

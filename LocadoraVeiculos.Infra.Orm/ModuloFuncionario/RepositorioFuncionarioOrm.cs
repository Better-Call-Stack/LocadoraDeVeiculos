using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm
    {
        private DbSet<Funcionario> funcionarios;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioFuncionarioOrm(IContextoPersistencia dbContext)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)dbContext;
            funcionarios = this.dbContext.Set<Funcionario>();
        }

        public void Inserir(Funcionario novoRegistro)
        {
            funcionarios.Add(novoRegistro);
        }

        public void Editar(Funcionario registro)
        {
            funcionarios.Update(registro);
        }

        public void Excluir(Funcionario registro)
        {
            funcionarios.Remove(registro);
        }

        public Funcionario SelecionarFuncionarioPorCPF(string cpf)
        {
            return funcionarios.FirstOrDefault(x => x.CPF == cpf);
        }

        public Funcionario SelecionarPorId(Guid id)
        {
            return funcionarios.SingleOrDefault(x => x.Id == id);
        }

        public Funcionario SelecionarFuncionarioPorLogin(string login)
        {
            return funcionarios.FirstOrDefault(x => x.Login == login);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarios.ToList();
        }

       
    }
}

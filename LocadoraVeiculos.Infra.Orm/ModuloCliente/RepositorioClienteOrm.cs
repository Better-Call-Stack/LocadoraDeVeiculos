using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm 
    {
        private DbSet<Cliente> clientes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioClienteOrm(IContextoPersistencia dbContext)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)dbContext;
            clientes = this.dbContext.Set<Cliente>();
        }

        public void Inserir(Cliente novoRegistro)
        {
            clientes.Add(novoRegistro);
        }

        public void Editar(Cliente registro)
        {
            clientes.Update(registro);
        }

        public void Excluir(Cliente registro)
        {
            clientes.Remove(registro);
        }

        public Cliente SelecionarClientePorCPF(string cpf)
        {
            return clientes.FirstOrDefault(x => x.CPF == cpf);
        }

        public Cliente SelecionarClientePorCNPJ(string cnpj)
        {
            return clientes.FirstOrDefault(x => x.CNPJ == cnpj);
        }


        public Cliente SelecionarPorId(Guid id)
        {
            return clientes.SingleOrDefault(x => x.Id == id);
        }


        public List<Cliente> SelecionarTodos()
        {
            return clientes.ToList();
        }
    }
}

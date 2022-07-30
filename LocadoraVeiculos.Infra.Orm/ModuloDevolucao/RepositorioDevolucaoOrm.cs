using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloDevolucao
{
    public class RepositorioDevolucaoOrm : IRepositorioDevolucao
    {
        private DbSet<Devolucao> devolucao;
        private readonly LocadoraDeVeiculosDbContext dbContext;
        public RepositorioDevolucaoOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            devolucao = dbContext.Set<Devolucao>();
            this.dbContext = dbContext;
        }
        public void Inserir(Devolucao novoRegistro)
        {
            devolucao.Add(novoRegistro);
        }

        public void Editar(Devolucao registro)
        {
            devolucao.Update(registro);
        }

        public void Excluir(Devolucao registro)
        {
            devolucao.Remove(registro);
        }

        public Devolucao SelecionarPorId(Guid id)
        {
            return devolucao.SingleOrDefault(d => d.Id == id);
        }
        public List<Devolucao> SelecionarTodos(bool incluirLocacao = false)
        {
            if (incluirLocacao)
                return devolucao.Include(d => d.Locacao).ToList();

            return devolucao.ToList();
        }

        public List<Devolucao> SelecionarTodos()
        {
            return devolucao.ToList();
        }
    }
}

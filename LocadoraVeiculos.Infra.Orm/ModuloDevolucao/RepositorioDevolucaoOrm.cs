using LocadoraDeVeiculos.Dominio.Compartilhado;
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
        public RepositorioDevolucaoOrm(IContextoPersistencia dbContext)
        {
            this.dbContext = (LocadoraDeVeiculosDbContext)dbContext;
            devolucao = this.dbContext.Set<Devolucao>();
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
        public List<Devolucao> SelecionarTodos()
        {
            /*if (incluirLocacao)
                return devolucao.Include(d => d.Locacao).ToList();

            return devolucao.ToList();*/

            return devolucao
                     .Include(x => x.Locacao)
                     .Include(x => x.Locacao.Taxas)

                     .ToList();
        }

        /*public List<Devolucao> SelecionarTodos()
        {
            return devolucao.ToList();
        }*/
    }
}

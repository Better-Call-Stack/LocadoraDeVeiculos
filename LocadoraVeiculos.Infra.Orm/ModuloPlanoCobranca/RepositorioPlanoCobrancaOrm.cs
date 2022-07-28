using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca
{
    public class RepositorioPlanoCobrancaOrm : IRepositorioPlanoDeCobranca
    {
        private DbSet<PlanoDeCobranca> planoDeCobrancas;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioPlanoCobrancaOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            planoDeCobrancas = dbContext.Set<PlanoDeCobranca>();
            this.dbContext = dbContext;
        }
        public void Inserir(PlanoDeCobranca novoRegistro)
        {
            planoDeCobrancas.Add(novoRegistro);
        }

        public void Editar(PlanoDeCobranca registro)
        {
            planoDeCobrancas.Update(registro);
        }

        public void Excluir(PlanoDeCobranca registro)
        {
            planoDeCobrancas.Remove(registro);
        }

        public PlanoDeCobranca SelecionarPorId(Guid id)
        {
            return planoDeCobrancas.SingleOrDefault(c => c.Id == id);
        }

        public List<PlanoDeCobranca> SelecionarTodos(bool incluirGrupoVeiculos = false)
        {
            if (incluirGrupoVeiculos)
                return planoDeCobrancas.Include(c => c.GrupoDeVeiculos).ToList();

            return planoDeCobrancas.ToList();
        }

        public List<PlanoDeCobranca> SelecionarTodos()
        {
            return planoDeCobrancas.ToList();
        }
    }
}

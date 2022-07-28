using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosOrm : IRepositorioGrupoVeiculos
    {
        private DbSet<GrupoDeVeiculos> grupoVeiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioGrupoVeiculosOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            grupoVeiculos = dbContext.Set<GrupoDeVeiculos>();
            this.dbContext = dbContext;
        }
        public void Inserir(GrupoDeVeiculos novoRegistro)
        {
            grupoVeiculos.Add(novoRegistro);
        }

        public void Editar(GrupoDeVeiculos registro)
        {
            grupoVeiculos.Update(registro);
        }

        public void Excluir(GrupoDeVeiculos registro)
        {
           grupoVeiculos.Remove(registro);
        }

        public GrupoDeVeiculos SelecionarGrupoVeiculosPorNome(string nome)
        {
            return grupoVeiculos.FirstOrDefault(x => x.Nome == nome);
        }

        public GrupoDeVeiculos SelecionarPorId(Guid id)
        {
            return grupoVeiculos.SingleOrDefault(x => x.Id == id);
        }

        public List<GrupoDeVeiculos> SelecionarTodos()
        {
            return grupoVeiculos.ToList();
        }
    }
}

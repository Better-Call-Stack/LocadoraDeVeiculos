using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloOrm
{
    public class RepositorioLocacaoOrm
    {
        private DbSet<Locacao> locacoes;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioLocacaoOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            locacoes = dbContext.Set<Locacao>();
            this.dbContext = dbContext;
        }

        public void Inserir(Locacao novoRegistro)
        {
            locacoes.Add(novoRegistro);
        }

        public void Editar(Locacao registro)
        {
            locacoes.Update(registro);
        }

        public void Excluir(Locacao registro)
        {
            locacoes.Remove(registro);
        }

        public Locacao SelecionarPorId(Guid id)
        {
            return locacoes.SingleOrDefault(x => x.Id == id);
        }


        public List<Locacao> SelecionarTodos()
        {
            return locacoes
                    .Include(x => x.Cliente)
                    .Include(x => x.Condutor)
                    .Include(x => x.Taxas)
                    .Include(x => x.PlanoDeCobranca)
                    .Include(x => x.Veiculo)
                    .ToList();
        }
    }
}

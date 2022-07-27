using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm
    {
        private DbSet<Condutor> condutores;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioCondutorOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            condutores = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }

        public void Inserir(Condutor novoRegistro)
        {
            condutores.Add(novoRegistro);
        }

        public void Editar(Condutor registro)
        {
            condutores.Update(registro);
        }

        public void Excluir(Condutor registro)
        {
            condutores.Remove(registro);
        }

        public Condutor SelecionarCondutorPorCPF(string cpf)
        {
            return condutores.FirstOrDefault(x => x.CPF == cpf);
        }

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            return condutores.FirstOrDefault(x => x.CNH == cnh);
        }


        public Condutor SelecionarPorId(Guid id)
        {
            return condutores.SingleOrDefault(x => x.Id == id);
        }


        public List<Condutor> SelecionarTodos(bool incluirCliente = false)
        {
                return condutores
                    .Include(x => x.Cliente)
                    .ToList();

        }
    }
}

using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraVeiculos.Infra.Orm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm
    {
        private DbSet<Veiculo> veiculos;
        private readonly LocadoraDeVeiculosDbContext dbContext;

        public RepositorioVeiculoOrm(LocadoraDeVeiculosDbContext dbContext)
        {
            veiculos = dbContext.Set<Veiculo>();
            this.dbContext = dbContext;
        }
        public void Inserir(Veiculo novoRegistro)
        {
            veiculos.Add(novoRegistro);
        }

        public void Editar(Veiculo registro)
        {
            veiculos.Update(registro);
        }

        public void Excluir(Veiculo registro)
        {
            veiculos.Remove(registro);
        }

        public Veiculo SelecionarPorId(Guid id)
        {
            return veiculos.SingleOrDefault(v => v.Id == id);
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return veiculos.SingleOrDefault(v => v.Placa == placa);
        }

        public List<Veiculo> SelecionarTodos(bool incluirGrupoVeiculos = false)
        {
            if (incluirGrupoVeiculos)
                return veiculos.Include(v => v.Grupo).ToList();

            return veiculos.ToList();
        }

        public List<Veiculo> SelecionarTodos()
        {
            return veiculos.Include(x => x.Grupo)
                .ToList();
        }
    }
}

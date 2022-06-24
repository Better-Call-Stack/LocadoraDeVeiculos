using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloGrupoVeiculos
{
    public class RepositorioGrupoVeiculosEmBancoDados : IRepositorioGrupoVeiculos
    {
        public ValidationResult Editar(GrupoDeVeiculos registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(GrupoDeVeiculos registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(GrupoDeVeiculos novoRegistro)
        {
            throw new NotImplementedException();
        }

        public GrupoDeVeiculos SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<GrupoDeVeiculos> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}

using FluentValidation.Results;
using System;
using System.Collections.Generic;


namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface Irepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);

        void Editar(T registro);

        void Excluir(T registro);

        List<T> SelecionarTodos();

        T SelecionarPorId(Guid id);
    }
}

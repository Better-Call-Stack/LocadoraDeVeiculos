using FluentValidation.Results;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private RepositorioCondutor repositorioCondutor;
        private ValidadorCondutor validadorCondutor;

        public ServicoCondutor(RepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor condutor)
        {
            Log.Logger.Debug("Tentando inserir condutor... {@c}", condutor);


            var resultadoValidacao = Validar(condutor);


            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Inserir(condutor);
                Log.Logger.Debug("Condutor {CondutoreId} inserido com sucesso", condutor.Id);
            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir um Condutor {CondutorId} - {Motivo}",
                        condutor.Id, erro.ErrorMessage);
                }

            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor condutor)
        {

            Log.Logger.Debug("Tentando editar condutor... {@c}", condutor);
            var resultadoValidacao = Validar(condutor);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Editar(condutor);
                Log.Logger.Debug("Condutor {CondutorNome} editado com sucesso", condutor.Nome);

            }
            else
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar um Condutor {CondutorNome} - {Motivo}",
                        condutor.Nome, erro.ErrorMessage);
                }
            }

            return resultadoValidacao;
        }

        private ValidationResult Validar(Condutor condutor)
        {
            validadorCondutor = new ValidadorCondutor();

            var resultadoValidacao = validadorCondutor.Validate(condutor);

            if (CpfDuplicado(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF Duplicado"));

            if (CnhDuplicada(condutor))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH Duplicada"));

            return resultadoValidacao;
        }

        private bool CpfDuplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return condutorEncontrado != null &&
                   condutorEncontrado.CPF == condutor.CPF &&
                   condutorEncontrado.Id != condutor.Id;
        }

        private bool CnhDuplicada(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCNH(condutor.CNH);

            return condutorEncontrado != null &&
                   condutorEncontrado.CNH == condutor.CNH &&
                   condutorEncontrado.Id != condutor.Id;
        }
    }
}

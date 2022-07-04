using LocadoraDeVeiculos.Infra.ModuloCondutor;
using LocadoraDeVeiculos.WinApp.Compartilhado;
using LocadoraVeiculos.Aplicacao.ModuloCondutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly RepositorioCondutor repositorioCondutor;
        private TabelaCondutorControl tabelaCondutor;
        private ServicoCondutor servicoCondutor;

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }
    }
}

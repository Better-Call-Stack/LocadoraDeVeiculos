using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCondutor
{
    public class ConiguracaoToolboxCondutor : ConfiguracaoToolboxBase
    {

        public override string TipoCadastro => "Controle de Condutores";

        public override string TooltipInserir => "Inserir um novo condutor";

        public override string TooltipEditar => "Editar um condutor";

        public override string TooltipExcluir => "Excluir um condutor";
    }
}

using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloDevolucao
{
    public class ConfiguracaoToolboxDevolucao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Devoluções";

        public override string TooltipInserir => "Inserir uma nova devolução";

        public override string TooltipEditar => "Editar uma devolução";

        public override string TooltipExcluir => "Excluir uma devolução";
    }
}

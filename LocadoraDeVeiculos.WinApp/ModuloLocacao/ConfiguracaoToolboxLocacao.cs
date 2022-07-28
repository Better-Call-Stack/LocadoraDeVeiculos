using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloLocacao
{
    public class ConfiguracaoToolboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Locações";

        public override string TooltipInserir => "Inserir uma nova locação";

        public override string TooltipEditar => "Editar uma locação";

        public override string TooltipExcluir => "Excluir uma locação";
    }
}

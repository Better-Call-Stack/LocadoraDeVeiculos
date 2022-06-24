using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Clientes";

        public override string TooltipInserir => "Inserir um novo cliente";

        public override string TooltipEditar => "Editar um compromisso cliente";

        public override string TooltipExcluir => "Excluir um compromisso cliente";
    }
}

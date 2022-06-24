using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoToolboxFuncionario
    {
        public  string TipoCadastro => "Cadastro de Contatos";

        public  string TooltipInserir { get { return "Inserir um novo contato"; } }

        public  string TooltipEditar { get { return "Editar um contato existente"; } }

        public  string TooltipExcluir { get { return "Excluir um contato existente"; } }

        public  string TooltipAgrupar { get { return "Agrupar contatos"; } }

        public  bool AgruparHabilitado { get { return true; } }
    }
}

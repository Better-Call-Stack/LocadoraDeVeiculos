using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloPlanoDeCobranca
{
    public class ConfiguracaoToolboxPlanoDeCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Plano de Cobrança";

        public override string TooltipInserir => "Inserir um novo plano de cobrança";

        public override string TooltipEditar => "Editar um plano de cobrança";

        public override string TooltipExcluir => "Excluir um plano de cobrança";
    }
}

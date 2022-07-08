using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloVeiculo
{
    public class ConfiguracaoToolboxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de veículos.";

        public override string TooltipInserir { get { return "Cadastrar veículo."; } }

        public override string TooltipEditar { get { return "Editar dados do veículo."; } }

        public override string TooltipExcluir
        {
            get { return "Excluir veículo."; }
        }
    }
}

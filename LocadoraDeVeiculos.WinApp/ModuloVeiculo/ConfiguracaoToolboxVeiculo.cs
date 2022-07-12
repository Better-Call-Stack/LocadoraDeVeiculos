using LocadoraDeVeiculos.WinApp.Compartilhado;

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

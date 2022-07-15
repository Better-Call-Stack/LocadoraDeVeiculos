using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloTaxa
{
    public class ConfiguracaoToolboxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Taxas";

        public override string TooltipInserir => "Inserir uma nova taxa";

        public override string TooltipEditar => "Editar uma taxa";

        public override string TooltipExcluir => "Excluir uma taxa";
    }
}

using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolboxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Clientes";

        public override string TooltipInserir => "Inserir um novo cliente";

        public override string TooltipEditar => "Editar um cliente";

        public override string TooltipExcluir => "Excluir um cliente";
    }
}

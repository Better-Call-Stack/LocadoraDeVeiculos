using LocadoraDeVeiculos.WinApp.Compartilhado;

namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Colaboradores.";

        public override string TooltipInserir { get { return "Cadastrar novo colaborador."; } }

        public override string TooltipEditar { get { return "Editar dados do colaborador."; } }

        public override string TooltipExcluir { get { return "Excluir dados do colaborador."; } }

    }
}

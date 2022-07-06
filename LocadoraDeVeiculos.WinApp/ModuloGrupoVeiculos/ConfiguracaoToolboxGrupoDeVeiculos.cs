using LocadoraDeVeiculos.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.ModuloGrupoVeiculos
{
    public class ConfiguracaoToolboxGrupoDeVeiculos : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Grupo de Veículos";

        public override string TooltipInserir => "Inserir um novo grupo de veículos";

        public override string TooltipEditar => "Editar um grupo de veículos";

        public override string TooltipExcluir => "Excluir um grupo de veículos";
    }
}

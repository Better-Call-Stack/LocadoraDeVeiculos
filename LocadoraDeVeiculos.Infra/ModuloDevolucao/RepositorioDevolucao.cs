using LocadoraDeVeiculos.Dominio.ModuloDevolucao;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloDevolucao
{
    public class RepositorioDevolucao : RepositorioBase<Devolucao, ValidadorDevolucao, MapeadorDevolucao>, IRepositorioDevolucao
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBDEVOLUCAO]
                (
                     [ID],
                     [VALORGASOLINA],
                     [QUILOMETRAGEM],
                     [DATADEVOLUCAO],
                     [VOLUMETANQUE],   
                     [LOCACAO_ID],
                     [TAXA_ID]
               )
            VALUES
                (
                     @ID,
                     @VALORGASOLINA,
                     @QUILOMETRAGEM,
                     @DATADEVOLUCAO,
                     @VOLUMETANQUE,
                     @LOCACAO_ID,
                     @TAXA_ID


                );";

        protected override string sqlEditar =>
            @" UPDATE [TBDEVOLUCAO]
                    SET 
                        [VALORGASOLINA] = @VALORGASOLINA,
                        [QUILOMETRAGEM] = @QUILOMETRAGEM,
                        [DATADEVOLUCAO] = @DATADEVOLUCAO,
                        [VOLUMETANQUE] = @VOLUMETANQUE,
                        [LOCACAO_ID] =@LOCACAO_ID,
                        [TAXA_ID] = @TAXA_ID


                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBDEVOLUCAO] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId => throw new NotImplementedException();

        protected override string sqlSelecionarTodos => throw new NotImplementedException();


    }
}

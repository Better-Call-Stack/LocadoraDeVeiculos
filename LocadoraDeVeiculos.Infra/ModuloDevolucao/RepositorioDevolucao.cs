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

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                    DV.[ID] AS DV_ID,
                    DV.[VALORGASOLINA] AS DV_VALORGASOLINA,
                    DV.[QUILOMETRAGEM] AS DV_QUILOMETRAGEM,
                    DV.[DATADEVOLUCAO] AS DV_DATADEVOLUCAO,
                    DV.[VOLUMETANQUE] AS DV_VOLUMETANQUE,
                
                    LC.[ID] AS LOCACAO_ID,
                    LC.[NOME] AS LOCACAO_NOME,

                    TX.[TAXA] AS TAXA_ID,
                    TX.[NOME] AS TAXA_NOME
                FROM
                    [TBDEVOLUCAO] AS PC INNER JOIN
                    [TBLOCACAO] AS LC,
                    [TBTAXA] AS TX
                ON
                    DV.[LOCACAO_ID] = LC.[ID],
                    DV.[TAXA_ID] = LC.[ID]
                WHERE
                    DV.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                    DV.[ID] AS DV_ID,
                    DV.[VALORGASOLINA] AS DV_VALORGASOLINA,
                    DV.[QUILOMETRAGEM] AS DV_QUILOMETRAGEM,
                    DV.[DATADEVOLUCAO] AS DV_DATADEVOLUCAO,
                    DV.[VOLUMETANQUE] AS DV_VOLUMETANQUE,
                
                    LC.[ID] AS LOCACAO_ID,
                    LC.[NOME] AS LOCACAO_NOME,

                    TX.[TAXA] AS TAXA_ID,
                    TX.[NOME] AS TAXA_NOME
                FROM
                    [TBDEVOLUCAO] AS PC INNER JOIN
                    [TBLOCACAO] AS LC,
                    [TBTAXA] AS TX
                ON
                    LC.[ID] = DV.[LOCACAO_ID],
                    TX.[ID] = DV.[TAXA_ID]
            ";


    }
}

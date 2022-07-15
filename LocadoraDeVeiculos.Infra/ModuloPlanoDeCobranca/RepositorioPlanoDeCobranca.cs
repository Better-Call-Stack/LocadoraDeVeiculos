using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.ModuloPlanoDeCobranca
{
    public class RepositorioPlanoDeCobranca : RepositorioBase<PlanoDeCobranca, ValidadorPlanoDeCobranca, MapeadorPlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        public RepositorioPlanoDeCobranca()
        {
        }
        protected override string sqlInserir =>
            @"INSERT INTO [TBPLANODECOBRANCA]
                (
                     [ID],
                     [VALORKMRODADO_PLANODIARIO],
                     [VALORPORDIA_PLANODIARIO],
                     [VALORKMRODADO_PLANOKMCONTROLADO],
                     [KMLIVREINCLUSO_PLANOKMCONTROLADO],
                     [VALORPORDIA_PLANOKMCONTROLADO],
                     [VALORPORDIA_PLANOKMLIVRE],
                     [GRUPOVEICULOS_ID]
               )
            VALUES
                (
                     @ID,
                     @VALORKMRODADO_PLANODIARIO,
                     @VALORPORDIA_PLANODIARIO,
                     @VALORKMRODADO_PLANOKMCONTROLADO,
                     @KMLIVREINCLUSO_PLANOKMCONTROLADO,
                     @VALORPORDIA_PLANOKMCONTROLADO,
                     @VALORPORDIA_PLANOKMLIVRE,
                     @GRUPOVEICULOS_ID


                );";

        protected override string sqlEditar =>
            @" UPDATE [TBPLANODECOBRANCA]
                    SET 
                        [VALORKMRODADO_PLANODIARIO] = @VALORKMRODADO_PLANODIARIO,
                        [VALORPORDIA_PLANODIARIO] = @VALORPORDIA_PLANODIARIO,
                        [VALORKMRODADO_PLANOKMCONTROLADO] = @VALORKMRODADO_PLANOKMCONTROLADO,
                        [KMLIVREINCLUSO_PLANOKMCONTROLADO] =@KMLIVREINCLUSO_PLANOKMCONTROLADO,
                        [VALORPORDIA_PLANOKMCONTROLADO] = @VALORPORDIA_PLANOKMCONTROLADO,
                        [VALORPORDIA_PLANOKMLIVRE] = @VALORPORDIA_PLANOKMLIVRE,
                        [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID


                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANODECOBRANCA] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                PC.[ID] AS PC_ID,
                PC.[VALORKMRODADO_PLANODIARIO] AS PC_VALORKMRODADO_PLANODIARIO,
                PC.[VALORPORDIA_PLANODIARIO] AS PC_VALORPORDIA_PLANODIARIO,
                PC.[VALORKMRODADO_PLANOKMCONTROLADO] AS PC_VALORKMRODADO_PLANOKMCONTROLADO,
                PC.[KMLIVREINCLUSO_PLANOKMCONTROLADO] AS PC_KMLIVREINCLUSO_PLANOKMCONTROLADO,
                PC.[VALORPORDIA_PLANOKMCONTROLADO] AS PC_VALORPORDIA_PLANOKMCONTROLADO,
                PC.[VALORPORDIA_PLANOKMLIVRE] AS PC_VALORPORDIA_PLANOKMLIVRE,
                
                GV.[ID] AS GRUPO_ID,
                GV.[NOME] AS GRUPO_NOME
            FROM
                [TBPLANODECOBRANCA] AS PC INNER JOIN
                [TBGRUPOVEICULOS] AS GV
            ON
                PC.[GRUPOVEICULOS_ID] = GV.[ID]
            WHERE
                PC.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                PC.[ID] AS PC_ID,
                PC.[VALORKMRODADO_PLANODIARIO] AS PC_VALORKMRODADO_PLANODIARIO,
                PC.[VALORPORDIA_PLANODIARIO] AS PC_VALORKMRODADO_PLANODIARIO,
                PC.[VALORKMRODADO_PLANOKMCONTROLADO] AS PC_VALORKMRODADO_PLANOKMCONTROLADO,
                PC.[KMLIVREINCLUSO_PLANOKMCONTROLADO] AS PC_KMLIVREINCLUSO_PLANOKMCONTROLADO,
                PC.[VALORPORDIA_PLANOKMCONTROLADO] AS PC_VALORPORDIA_PLANOKMCONTROLADO,
                PC.[VALORPORDIA_PLANOKMLIVRE] AS PC_VALORPORDIA_PLANOKMLIVRE,
                
                GV.[ID] AS GRUPO_ID,
                GV.[NOME] AS GRUPO_NOME
            FROM
                [TBPLANODECOBRANCA] AS PC INNER JOIN
                [TBGRUPOVEICULOS] AS GV
            ON
                GV.[ID] = PC.[GRUPOVEICULOS_ID]
            ";

        public PlanoDeCobranca SelecionarGrupoDeVeiculosDoPlanoDeCobrancaPorId(Guid id)
        {
            return SelecionarPorParametro(sqlSelecionarPorId, new SqlParameter("Id", id));
        }
    }
}

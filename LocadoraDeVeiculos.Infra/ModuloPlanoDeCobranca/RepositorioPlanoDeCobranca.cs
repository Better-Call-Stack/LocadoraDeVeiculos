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
                     @VALORKMRODADO_PLANODIARIO,
                     @VALORPORDIA_PLANODIARIO,
                     @VALORKMRODADO_PLANOKMCONTROLADO,
                     @KMLIVREINCLUSO_PLANOKMCONTROLADO,
                     @VALORPORDIA_PLANOKMCONTROLADO,
                     @VALORPORDIA_PLANOKMLIVRE,
                     @GRUPOVEICULOS_ID


                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBPLANODECOBRANCA]
                    SET 
                        [VALORKMRODADO_PLANODIARIO] = @TXTVALORKMRODADO_PLANODIARIO,
                        [VALORPORDIA_PLANODIARIO] = @TXTVALORPORDIA_PLANODIARIO,
                        [VALORKMRODADO_PLANOKMCONTROLADO] = @TXTVALORKMRODADO_PLANOKMCONTROLADO,
                        [KMLIVREINCLUSO_PLANOKMCONTROLADO] =@TXTKMLIVREINCLUSO_PLANOKMCONTROLADO,
                        [VALORPORDIA_PLANOKMCONTROLADO] = @TXTVALORPORDIA_PLANOKMCONTROLADO,
                        [VALORPORDIA_PLANOKMLIVRE] = @TXTVALORPORDIA_PLANOKMLIVRE,
                        [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID


                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANODECOBRANCA] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                PC.[ID],
                PC.[VALORKMRODADO_PLANODIARIO],
                PC.[VALORPORDIA_PLANODIARIO],
                PC.[VALORKMRODADO_PLANOKMCONTROLADO],
                PC.[KMLIVREINCLUSO_PLANOKMCONTROLADO],
                PC.[VALORPORDIA_PLANOKMCONTROLADO],
                PC.[VALORPORDIA_PLANOKMLIVRE],
                
                GV.[ID],
                GV.[NOME]
            FROM
                [TBPLANODECOBRANCA] AS PC INNER JOIN
                [TBGRUPOVEICULOS] AS GV
            ON
                PC.[GRUPOVEICULOS_ID] = GV.[ID]
            WHERE
                PC.[ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                PC.[ID],
                PC.[VALORKMRODADO_PLANODIARIO],
                PC.[VALORPORDIA_PLANODIARIO],
                PC.[VALORKMRODADO_PLANOKMCONTROLADO],
                PC.[KMLIVREINCLUSO_PLANOKMCONTROLADO],
                PC.[VALORPORDIA_PLANOKMCONTROLADO],
                PC.[VALORPORDIA_PLANOKMLIVRE],
                
                GV.[ID],
                GV.[NOME]
            FROM
                [TBPLANODECOBRANCA] AS PC INNER JOIN
                [TBGRUPOVEICULOS] AS GV
            ON
                GV.[ID] = PC.[GRUPOVEICULOS_ID]
            ";

        public PlanoDeCobranca SelecionarGrupoDeVeiculosDoPlanoDeCobrancaPorId(int id)
        {
            return SelecionarPorParametro(sqlSelecionarPorId, new SqlParameter("Id", id));
        }
    }
}

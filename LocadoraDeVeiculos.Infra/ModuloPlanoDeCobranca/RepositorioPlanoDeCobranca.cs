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
            Db.ExecutarSql("DELETE FROM TBPLANODECOBRANCA; DBCC CHECKIDENT (TBPLANODECOBRANCA, RESEED, 0)");
        }
        protected override string sqlInserir =>
            @"INSERT INTO [TBPLANODECOBRANCA]
                (
                     [TXTVALORKMRODADO_PLANODIARIO],
                     [TXTVALORPORDIA_PLANODIARIO],
                     [TXTVALORKMRODADO_PLANOKMCONTROLADO],
                     [TXTKMLIVREINCLUSO_PLANOKMCONTROLADO],
                     [TXTVALORPORDIA_PLANOKMCONTROLADO],
                     [TXTVALORPORDIA_PLANOKMLIVRE],
                     [GRUPOVEICULOS_ID]
               )
            VALUES
                (
                     @TXTVALORKMRODADO_PLANODIARIO,
                     @TXTVALORPORDIA_PLANODIARIO,
                     @TXTVALORKMRODADO_PLANOKMCONTROLADO,
                     @TXTKMLIVREINCLUSO_PLANOKMCONTROLADO,
                     @TXTVALORPORDIA_PLANOKMCONTROLADO,
                     @TXTVALORPORDIA_PLANOKMLIVRE,
                     @GRUPOVEICULOS_ID


                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBPLANODECOBRANCA]
                    SET 
                        [TXTVALORKMRODADO_PLANODIARIO] = @TXTVALORKMRODADO_PLANODIARIO,
                        [TXTVALORPORDIA_PLANODIARIO] = @TXTVALORPORDIA_PLANODIARIO,
                        [TXTVALORKMRODADO_PLANOKMCONTROLADO] = @TXTVALORKMRODADO_PLANOKMCONTROLADO,
                        [TXTKMLIVREINCLUSO_PLANOKMCONTROLADO] =@TXTKMLIVREINCLUSO_PLANOKMCONTROLADO,
                        [TXTVALORPORDIA_PLANOKMCONTROLADO] = @TXTVALORPORDIA_PLANOKMCONTROLADO,
                        [TXTVALORPORDIA_PLANOKMLIVRE] = @TXTVALORPORDIA_PLANOKMLIVRE,
                        [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID


                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANODECOBRANCA] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                PC.[ID],
                PC.[TXTVALORKMRODADO_PLANODIARIO],
                PC.[TXTVALORPORDIA_PLANODIARIO],
                PC.[TXTVALORKMRODADO_PLANOKMCONTROLADO],
                PC.[TXTKMLIVREINCLUSO_PLANOKMCONTROLADO],
                PC.[TXTVALORPORDIA_PLANOKMCONTROLADO],
                PC.[TXTVALORPORDIA_PLANOKMLIVRE],
                
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
                PC.[TXTVALORKMRODADO_PLANODIARIO],
                PC.[TXTVALORPORDIA_PLANODIARIO],
                PC.[TXTVALORKMRODADO_PLANOKMCONTROLADO],
                PC.[TXTKMLIVREINCLUSO_PLANOKMCONTROLADO],
                PC.[TXTVALORPORDIA_PLANOKMCONTROLADO],
                PC.[TXTVALORPORDIA_PLANOKMLIVRE],
                
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

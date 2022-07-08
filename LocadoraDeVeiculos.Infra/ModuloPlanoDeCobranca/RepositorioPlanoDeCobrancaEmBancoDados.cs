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
    public class RepositorioPlanoDeCobrancaEmBancoDados : RepositorioBase<PlanoDeCobranca, ValidadorPlanoDeCobranca, MapeadorPlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        public RepositorioPlanoDeCobrancaEmBancoDados()
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
                     [TXTVALORPORDIA_PLANOKMLIVRE])
            VALUES
                (
                     @TXTVALORKMRODADO_PLANODIARIO,
                     @TXTVALORPORDIA_PLANODIARIO,
                     @TXTVALORKMRODADO_PLANOKMCONTROLADO,
                     @TXTKMLIVREINCLUSO_PLANOKMCONTROLADO,
                     @TXTVALORPORDIA_PLANOKMCONTROLADO,
                     @TXTVALORPORDIA_PLANOKMLIVRE
                );SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @" UPDATE [TBPLANODECOBRANCA]
                    SET 
                        [TXTVALORKMRODADO_PLANODIARIO] = @TXTVALORKMRODADO_PLANODIARIO,
                        [TXTVALORPORDIA_PLANODIARIO] = @TXTVALORPORDIA_PLANODIARIO,
                        [TXTVALORKMRODADO_PLANOKMCONTROLADO] = @TXTVALORKMRODADO_PLANOKMCONTROLADO,
                        [TXTKMLIVREINCLUSO_PLANOKMCONTROLADO] =@TXTKMLIVREINCLUSO_PLANOKMCONTROLADO,
                        [TXTVALORPORDIA_PLANOKMCONTROLADO] = @TXTVALORPORDIA_PLANOKMCONTROLADO,
                        [TXTVALORPORDIA_PLANOKMLIVRE] = @TXTVALORPORDIA_PLANOKMLIVRE
                    WHERE [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBPLANODECOBRANCA] 
                    WHERE [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],
                [TXTVALORKMRODADO_PLANODIARIO],
                [TXTVALORPORDIA_PLANODIARIO],
                [TXTVALORKMRODADO_PLANOKMCONTROLADO],
                [TXTKMLIVREINCLUSO_PLANOKMCONTROLADO],
                [TXTVALORPORDIA_PLANOKMCONTROLADO],
                [TXTVALORPORDIA_PLANOKMLIVRE]
            FROM
                [TBPLANODECOBRANCA] AS PC LEFT JOIN
                [TBGRUPOVEICULOS] AS GV
            ON
                GV.ID = PC.ID
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
                PC.[GRUPOVEICULOS_ID]

            FROM
                [TBPLANODECOBRANCA] AS PC LEFT JOIN
                [TBGRUPOVEICULOS] AS GV
            ON
                GV.[ID] = PC.[ID]";

        public PlanoDeCobranca SelecionarPlanoDeCobrancaPorId(string id)
        {
            return SelecionarPorParametro(sqlSelecionarPorId, new SqlParameter("Id", id));
        }
    }
}

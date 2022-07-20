using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System.Data.SqlClient;


namespace LocadoraDeVeiculos.Infra.ModuloVeiculo
{
    public class RepositorioVeiculo : RepositorioBase<Veiculo, ValidadorVeiculo, MapeadorVeiculo>
    {
        protected override string sqlInserir =>
            @"INSERT INTO [TBVEICULO]
                (
                    [ID],
                    [MODELO],
                    [FABRICANTE],
                    [PLACA],
                    [COR],
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADEDOTANQUE],
                    [ANO],
                    [KMPERCORRIDO],
                    [STATUSVEICULO],
                    [GRUPOVEICULOS_ID],
                    [FOTOVEICULO]
                )
               VALUES
                (
                    @ID,
                    @MODELO,
                    @FABRICANTE,
                    @PLACA,
                    @COR,
                    @TIPOCOMBUSTIVEL,
                    @CAPACIDADEDOTANQUE,
                    @ANO,
                    @KMPERCORRIDO,
                    @STATUSVEICULO,
                    @GRUPOVEICULOS_ID,
                    @FOTOVEICULO
                );";

        protected override string sqlEditar =>
            @"UPDATE [TBVEICULO]
                SET
                    [MODELO] = @MODELO,
                    [FABRICANTE] = @FABRICANTE,
                    [PLACA] = @PLACA,
                    [COR] = @COR,
                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                    [CAPACIDADEDOTANQUE] = @CAPACIDADEDOTANQUE,
                    [ANO] = @ANO,
                    [KMPERCORRIDO] = @KMPERCORRIDO,
                    [STATUSVEICULO] = @STATUSVEICULO,
                    [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID,
                    [FOTOVEICULO] = @FOTOVEICULO
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBVEICULO]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                VEICULO.[ID] AS VEICULO_ID,                                                         
                VEICULO.[MODELO] AS VEICULO_MODELO,                                                        
                VEICULO.[FABRICANTE] AS VEICULO_FABRICANTE,                                                       
                VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,                                                       
                VEICULO.[COR] AS VEICULO_COR,
                VEICULO.[ANO] AS VEICULO_ANO,
                VEICULO.[KMPERCORRIDO] AS VEICULO_KMPERCORRIDO,                                                        
                VEICULO.[CAPACIDADEDOTANQUE] AS VEICULO_CAPACIDADE,                                                        
                VEICULO.[PLACA] AS VEICULO_PLACA,
                VEICULO.[STATUSVEICULO] AS VEICULO_STATUS,
                VEICULO.[FOTOVEICULO] AS VEICULO_FOTO,
                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME

                FROM 
                 [TBVEICULO] AS VEICULO
                  INNER JOIN [TBGRUPOVEICULOS] AS GRUPO ON 
                      VEICULO.GRUPOVEICULOS_ID = GRUPO.ID
                WHERE
                 VEICULO.ID = @ID";

        protected string sqlSelecionarPorPlaca =>
            @"SELECT 
                VEICULO.[ID] AS VEICULO_ID,                                                         
                VEICULO.[MODELO] AS VEICULO_MODELO,                                                        
                VEICULO.[FABRICANTE] AS VEICULO_FABRICANTE,                                                       
                VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,                                                       
                VEICULO.[COR] AS VEICULO_COR,
                VEICULO.[ANO] AS VEICULO_ANO,
                VEICULO.[KMPERCORRIDO] AS VEICULO_KMPERCORRIDO,                                                        
                VEICULO.[CAPACIDADEDOTANQUE] AS VEICULO_CAPACIDADE,                                                        
                VEICULO.[PLACA] AS VEICULO_PLACA,
                VEICULO.[STATUSVEICULO] AS VEICULO_STATUS,
                VEICULO.[FOTOVEICULO] AS VEICULO_FOTO,
                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME												 
                                                          
                FROM 
                 [TBVEICULO] AS VEICULO
                  INNER JOIN [TBGRUPOVEICULOS] AS GRUPO ON 
                      VEICULO.GRUPOVEICULOS_ID = GRUPO.ID
                WHERE
                 VEICULO.PLACA = @PLACA";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                VEICULO.[ID] AS VEICULO_ID,                                                         
                VEICULO.[MODELO] AS VEICULO_MODELO,                                                        
                VEICULO.[FABRICANTE] AS VEICULO_FABRICANTE,                                                       
                VEICULO.[TIPOCOMBUSTIVEL] AS VEICULO_TIPOCOMBUSTIVEL,                                                       
                VEICULO.[COR] AS VEICULO_COR,
                VEICULO.[ANO] AS VEICULO_ANO,
                VEICULO.[KMPERCORRIDO] AS VEICULO_KMPERCORRIDO,                                                        
                VEICULO.[CAPACIDADEDOTANQUE] AS VEICULO_CAPACIDADE,                                                        
                VEICULO.[PLACA] AS VEICULO_PLACA,
                VEICULO.[STATUSVEICULO] AS VEICULO_STATUS,
                VEICULO.[FOTOVEICULO] AS VEICULO_FOTO,
                GRUPO.[ID] AS GRUPO_ID,
                GRUPO.[NOME] AS GRUPO_NOME
                                                          
              FROM 
                [TBVEICULO] AS VEICULO
                 INNER JOIN [TBGRUPOVEICULOS] AS GRUPO ON 
                     VEICULO.GRUPOVEICULOS_ID = GRUPO.ID";

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return SelecionarPorParametro(sqlSelecionarPorPlaca, new SqlParameter("PLACA", placa));
        }

    }
}

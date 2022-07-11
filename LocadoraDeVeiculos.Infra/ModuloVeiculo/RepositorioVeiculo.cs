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
                    [MODELO],
                    [FABRICANTE],
                    [PLACA],
                    [COR],
                    [TIPOCOMBUSTIVEL],
                    [CAPACIDADEDOTANQUE],
                    [ANO],
                    [KMPERCORRIDO],
                    [STATUSVEICULO],
                    [GRUPOVEICULOS_ID]
                )
               VALUES
                (
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
                    @STATUSVEICULO
                )
                    SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar =>
            @"UPDATE [TBVEICULO]
                SET
                    [MODELO] = @MODELO,
                    [FABRICANTE] = @FABRICANTE,
                    [PLACA] = @PLACA,
                    [COR] = @COR,
                    [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL
                    [CAPACIDADEDOTANQUE] = @CAPACIDADEDOTANQUE,
                    [ANO] = @ANO,
                    [KMPERCORRIDO] = @KMPERCORRIDO,
                    [STATUSVEICULO] = @STATUSVEICULO,
                    [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBVEICULO]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                VEICULO.ID AS VEICULO_ID,                                                         
                VEICULO.MODELO,                                                        
                VEICULO.FABRICANTE,                                                       
                VEICULO.TIPOCOMBUSTIVEL,                                                       
                VEICULO.COR,
                VEICULO.ANO,
                VEICULO.KMPERCORRIDO,                                                        
                VEICULO.CAPACIDADEDOTANQUE,                                                        
                VEICULO.PLACA,
                VEICULO.STATUSVEICULO,
                GRUPO.ID AS GRUPOVEICULOS_ID,
                GRUPO.NOME AS GRUPOVEICULOS_NOME														 
                                                          
                FROM 
                 [TBVEICULO] AS VEICULO
                  INNER JOIN [TBGRUPOVEICULOS] AS GRUPO ON 
                      VEICULO.GRUPOVEICULOS_ID = GRUPO.ID
                WHERE
                 VEICULO.ID = @ID";

        protected string sqlSelecionarPorPlaca =>
            @"SELECT 
                VEICULO.ID AS VEICULO_ID,                                                         
                VEICULO.MODELO,                                                        
                VEICULO.FABRICANTE,                                                       
                VEICULO.TIPOCOMBUSTIVEL,                                                       
                VEICULO.COR,
                VEICULO.ANO,
                VEICULO.KMPERCORRIDO,                                                        
                VEICULO.CAPACIDADEDOTANQUE,                                                        
                VEICULO.PLACA,
                VEICULO.STATUSVEICULO,
                GRUPO.ID AS GRUPOVEICULOS_ID,
                GRUPO.NOME AS GRUPOVEICULOS_NOME														 
                                                          
                FROM 
                 [TBVEICULO] AS VEICULO
                  INNER JOIN [TBGRUPOVEICULOS] AS GRUPO ON 
                      VEICULO.GRUPOVEICULOS_ID = GRUPO.ID
                WHERE
                 VEICULO.PLACA = @PLACA";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                VEICULO.ID AS VEICULO_ID,                                                         
                VEICULO.MODELO,                                                        
                VEICULO.FABRICANTE,                                                       
                VEICULO.TIPOCOMBUSTIVEL,                                                       
                VEICULO.COR,
                VEICULO.ANO,
                VEICULO.KMPERCORRIDO,                                                        
                VEICULO.CAPACIDADEDOTANQUE,                                                        
                VEICULO.PLACA,
                VEICULO.STATUSVEICULO,
                GRUPO.ID AS GRUPOVEICULOS_ID,
                GRUPO.NOME AS GRUPOVEICULOS_NOME													 
                                                          
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

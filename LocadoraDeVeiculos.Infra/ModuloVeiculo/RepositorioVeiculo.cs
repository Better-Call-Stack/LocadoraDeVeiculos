using LocadoraDeVeiculos.Dominio.ModuloVeiculo;
using LocadoraDeVeiculos.Infra.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    @GRUPOVEICULOS_ID
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
                    [GRUPOVEICULOS_ID] = @GRUPOVEICULOS_ID,
                WHERE
                    [ID] = @ID";

        protected override string sqlExcluir =>
            @"DELETE FROM [TBVEICULO]
                WHERE
                    [ID] = @ID";

        protected override string sqlSelecionarPorId =>
            @"SELECT 
                [ID],       
                [MODELO],
                [FABRICANTE],
                [PLACA],             
                [COR],                    
                [TIPOCOMBUSTIVEL],
                [CAPACIDADEDOTANQUE],
                [ANO],
                [[KMPERCORRIDO],
                [GRUPOVEICULOS_ID]
            FROM
                [TBFORNECEDOR]
            WHERE
                [ID] = @ID";

        protected override string sqlSelecionarTodos =>
            @"SELECT 
                [ID],       
                [MODELO],
                [FABRICANTE],
                [PLACA],             
                [COR],                    
                [TIPOCOMBUSTIVEL],
                [CAPACIDADEDOTANQUE],
                [ANO],
                [[KMPERCORRIDO],
                [GRUPOVEICULOS_ID]
            FROM
                [TBFORNECEDOR]";
    }
}

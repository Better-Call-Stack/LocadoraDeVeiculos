using System.Data.SqlClient;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public static class Db
    {
        private static string enderecoBanco =
            @"Data Source=(LocalDB)\MSSqlLocalDB;
              Initial Catalog=LocadoraDeVeiculosDB;
              Integrated Security=True";

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

    }
}

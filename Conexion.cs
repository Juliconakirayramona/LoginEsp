namespace loginclaro;
using Oracle.ManagedDataAccess.Client;

public class Conexion
{
    static void Main()
    {
        string connectionString = "User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES";

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
                string query = "SELECT * FROM ESTUDIANTES";
                OracleCommand command = new OracleCommand(query, connection);
                OracleDataReader reader = command.ExecuteReader();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar a la base de datos: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}


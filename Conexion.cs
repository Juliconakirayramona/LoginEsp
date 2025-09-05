namespace loginclaro;
using Oracle.ManagedDataAccess.Client;
using System;

public class Conexion
{
	/// <summary>
	/// Creamos la conexión a la base de datos, y hacemos una consulta para ver si la conexión es exitosa,
	/// ponemos el try catch para manejar los posibles errores, y el finally para cerrar la conexión.
	/// también cabe agregar que hacemos un query para seleccionar todo de la tabla estudiantes
	/// </summary>
	/// <exception cref="InvalidOperationException"></exception>
    static void Main()
    {

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
                OracleDataReader reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
        }
    }
}


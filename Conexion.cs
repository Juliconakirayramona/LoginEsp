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
		String connectionString = "User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES";

		using (OracleConnection connection = new OracleConnection(connectionString))
		{
			try
			{
				connection.Open();
				Console.WriteLine("Connection successful!");
				String query = "SELECT * FROM ESTUDIANTES";
				using (var command = new OracleCommand(query, connection))
				{
					OracleDataReader reader = command.ExecuteReader();
				}				
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("Error al conectar a la base de datos: " + ex.Message);
			}
			finally
			{
				connection.Close();
			}
		}
	}
}


using loginclaro.modelos;
using System;
using System.Collections.Generic;
namespace loginclaro.Servicio
{
	/// <summary>
	/// Creamos la clase EstudianteServicio y la conexción a la base de datos
	/// </summary>
	public class EstudianteServicio
	{
		private readonly String _connectionString;
		public EstudianteServicio(String connectionString)
		{
			this._connectionString = connectionString;
		}
		/// <summary>
		/// Método para agregar estudiantes a la base de datos, desde la api
		/// </summary>
		/// <param name="estudiante"> Para acceder a los datos de la clase estudiante</param>
		/// <exception cref="InvalidOperationException"> Por si sale algún error, saber cuál es</exception>
		public void AgregarEstudiante(Estudiantes estudiante)
		{
			try
			{
				using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString))
				{
					connection.Open();
					var query = "INSERT INTO ESTUDIANTES (\"Id\", \"Nombre\") VALUES (:Id, :Nombre)";
					using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
					{
						command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("Id", estudiante.Id));
						command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("Nombre", estudiante.Nombre));
						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				// Manejo de errores
				throw new InvalidOperationException("Error al agregar estudiante: " + ex.Message);
			}

		}
		/// <summary>
		/// Obtener los estudiantes que tenemos en la base de datos, 
		///y mostrarlos en la api, y los metemos en la lista para mostrarlos
		/// </summary>
		/// <returns> retornamos los estudiantes en la lista</returns>
		/// <exception cref="InvalidOperationException"> Por si sale algún error</exception>
		public List<Estudiantes> ObtenerEstudiantes()
		{
			var estudiantes = new List<Estudiantes>();
			try
			{
				using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString))
				{
					connection.Open();
					var query = "SELECT \"Id\", \"Nombre\" FROM ESTUDIANTES";
					using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
					{
						using (Oracle.ManagedDataAccess.Client.OracleDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								estudiantes.Add(new Estudiantes
								{
									Id = reader.GetInt32(0),
									Nombre = reader.GetString(1)
								});
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				// Manejo de errores
				throw new InvalidOperationException("Error al obtener estudiantes: " + ex.Message);
			}
			return estudiantes;
		}
	}
}

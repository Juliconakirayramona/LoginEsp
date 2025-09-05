using loginclaro.modelos;
using Oracle.ManagedDataAccess.Client;


namespace loginclaro.Servicio
{
	/// <summary>
	///	Acá creamos la clase Materia servicio, luego hacemos la conexión 
	///	a oracle para utilizar los demás servicios
	/// </summary>
	public class MateriaServicio
	{
		private readonly String connectionString;
		public MateriaServicio(String connectionString)
		{
			this.connectionString = connectionString;
		}
		/// <summary>
		///	En este método agregamos las materias a la base de datos, es importante poner las columnas con "\"
		///	para que este funciones, simplemente desde el JSON, agregamos los datos y se envían a la base de datos
		/// </summary>
		/// <param name="materia">Este parametro, es de la clase mayteria y me deja acceder a los atrivutos de mi materia
		/// Con la instancia new Oracle, estamos agregando los datos que nos llegaron del JSON</param>
		/// <exception cref="InvalidOperationException">Esta nos permite dar exactamente el error, si lo hay</exception>
		public void AgregarMateria(Materias materia)
		{
			try
			{
				using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(connectionString))
				{
					connection.Open();
					var query = @"INSERT INTO MATERIAS 
									(""Id"" 
									""Nombre""
									""EstudianteId"" 
									""NOTAS"" ) 
									VALUES (:Id, :Nombre, :EstudianteId,:NOTAS)";
					using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
					{
						command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("Id", materia.Id));
						command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("Nombre", materia.Nombre));
						command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("EstudianteId", materia.EstudianteId));
						command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("NOTAS", materia.Nota));
						command.ExecuteNonQuery();
					}
				}
			}//Cierre del try
			catch (Exception ex)
			{
				// Manejo de errores
				throw new InvalidOperationException("Error al agregar materia: " + ex.Message);
			}//Cierre del catch
		}
		/// <summary>
		///	En este método obtenemos las materias que tenemos en la base de datos,
		///	creamos un query y selecionamos las columnas que queremos mostrar,
		///	luego con el data reader, leemos los datos y los almacenamos en una lista
		/// </summary>
		/// <returns>Al hacer lo recién mencionado, simplemente regresamos la materia o materias</returns>
		/// <exception cref="InvalidOperationException"> Este para encontrar posibles errores </exception>
		public List<Materias> ObtenerMaterias()
		{
			var materias = new List<Materias>();
			try
			{
				using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(connectionString))
				{
					connection.Open();
					var query = @"SELECT ""Id"",
									""Nombre""
									""EstudianteId""
									""NOTAS""
									FROM MATERIAS;";

					using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
					{
						using (Oracle.ManagedDataAccess.Client.OracleDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								materias.Add(new Materias
								{
									Id = reader.GetInt32(0),
									Nombre = reader.GetString(1),
									EstudianteId = reader.GetInt32(2),
									Nota = reader.IsDBNull(3) ? 0 : reader.GetDouble(3)
								});
							}
						}
					}
				}
			}//Cierre del try
			catch (Exception ex)
			{
				throw new InvalidOperationException("Error al obtener materias: " + ex.Message);
			}//Cierre del catch
			return materias;
		}
		/// <summary>
		/// Acá calculamos el promedio de las notas, hacemos un query con AVG para sacar el promedio,
		/// buscamos el estudiante por su ID y regresamos el promedio
		/// </summary>
		/// <param name="EstudianteId"> Este nos sirve como parametro de busqueda, para elegir qué estudiante 
		/// le queremos sacar el promedio </param>
		/// <returns> retorna el promedio</returns>
		public Double Promedio(Int32 EstudianteId)
		{
			Double promedio = 0;
			using var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(connectionString);
			{
				connection.Open();
				var query = @"SELECT AVG(""NOTAS"")
								FROM MATERIAS 
								WHERE ""EstudianteId"" = :EstudianteId";

				using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
				{
					command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("EstudianteId", EstudianteId));
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						promedio = Convert.ToDouble(result);
						return promedio;
					}//Cierre del if
					return promedio;
				}
			}
		}
		/// <summary>
		/// En este método eliminamos una materia por su ID, hacemos un query de DELETE, Buscando el ID que queremos eliminar
		/// </summary>
		/// <param name="id">también mandamos un parámetro desde el swagger para que sepa qué ID eliminar, se elimina también desde la base de datos</param>
		public void EliminarMateria(Int32 id)
		{
			using (var connection = new OracleConnection(connectionString))
			{
				connection.Open();
				var query = @"DELETE FROM MATERIAS 
								WHERE ""Id"" = :Id";

				using (var command = new OracleCommand(query, connection))
				{
					command.Parameters.Add(new OracleParameter("Id", id));
					command.ExecuteNonQuery();
				}
			}
		}
	}
}

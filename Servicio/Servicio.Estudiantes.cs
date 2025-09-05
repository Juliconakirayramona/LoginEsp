using loginclaro.modelos;
namespace loginclaro.Servicio
{
    public class EstudianteServicio
    {
        private readonly string _connectionString;

        public EstudianteServicio(string connectionString)
        {
            this._connectionString = connectionString;
        }
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
                throw new Exception("Error al agregar estudiante: " + ex.Message);
            }

        }
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
                        using (var reader = command.ExecuteReader())
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
                throw new Exception("Error al obtener estudiantes: " + ex.Message);
            }
            return estudiantes;
        }
    }
}
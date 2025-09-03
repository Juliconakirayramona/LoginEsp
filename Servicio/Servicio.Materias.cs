using loginclaro.modelos;
using System.Data;
using System.Xml;

namespace loginclaro.Servicio
{
    public class MateriaServicio
    {
        private readonly string _connectionString;

        public MateriaServicio(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public void AgregarMateria(Materias materia)
        {
            try
            {
                using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString))
                {
                    connection.Open();
                    var query = "INSERT INTO MATERIAS (\"Id\", \"Nombre\",\"EstudianteId\", \"NOTAS\" ) VALUES (:Id, :Nombre, :EstudianteId,:Nota)";
                    using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
                    {
                        command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("Id", materia.Id));
                        command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("Nombre", materia.Nombre));
                        command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("EstudianteId", materia.Nota));
                        command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("NOTAS", materia.EstudianteId));
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al agregar materia: " + ex.Message);
            }
        }
        public List<Materias> ObtenerMaterias()
        {
            var materias = new List<Materias>();
            try
            {
                using (var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString))
                {
                    connection.Open();
                    var query = "SELECT \"Id\", \"Nombre\",\"EstudianteId\", \"NOTAS\" FROM MATERIAS";
                    using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                materias.Add(new Materias
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1),
                                    EstudianteId = reader.GetInt32(2),
                                    Nota = reader.IsDBNull(3)  ? 0 : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener materias: " + ex.Message);
            }
            return materias;
        }
        public decimal Promedio(int EstudianteId)
        {
            decimal promedio = 0;

            using var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_connectionString);
            {
                connection.Open();
                var query = "SELECT AVG(\"NOTAS\") FROM MATERIAS WHERE \"EstudianteId\" = :EstudianteId";
                using (var command = new Oracle.ManagedDataAccess.Client.OracleCommand(query, connection))
                {
                    command.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("EstudianteId", EstudianteId));
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        promedio = Convert.ToDecimal(result);
                        return promedio;
                    }
                    return promedio;
                }
            }
        }
    }
}

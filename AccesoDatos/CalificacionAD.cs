using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class CalificacionAD
    {
        string conectionString = ConfigurationManager.ConnectionStrings["conx"].ConnectionString;
        public int InsertarCalificacionAD(Calificaciones calificaciones)
        {
            int calificacionesid = 0;
            // INSTANCIAMOS LA CONEXION A LA BD
            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                //LLAMAMOS AL SP DE LA BASE DE DATOS 
                using (SqlCommand sqlCommand = new SqlCommand("SP_INSERTAR_EJERCICIO", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idAlumno", calificaciones.Id_Alumno);
                    sqlCommand.Parameters.AddWithValue("@nombre", calificaciones.Nombre);
                    sqlCommand.Parameters.AddWithValue("@realizado", calificaciones.Realizado);
                    sqlCommand.Parameters.AddWithValue("@calificacion", calificaciones.Calificacion);
                    sqlConnection.Open();
                    calificacionesid = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
                return calificacionesid;
            }
        }

        public List<Calificaciones> ListarCalificacionesAD()
        {
            List<Calificaciones> lista = new List<Calificaciones>();

            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("ListarCalificaciones", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Calificaciones calificaciones = new Calificaciones();
                        calificaciones.IdEjercicio = Convert.ToInt32(reader["IdEjercicio"]);
                        calificaciones.Id_Alumno = Convert.ToInt32(reader["Id_Alumno"]);
                        calificaciones.Primer_Nombre = Convert.ToString(reader["Primer_Nombre"]);
                        calificaciones.Nombre = Convert.ToString(reader["Nombre"]);
                        calificaciones.Realizado = Convert.ToBoolean(reader["Realizado"]);
                        calificaciones.Calificacion = Convert.ToInt32(reader["Calificacion"]);
                        lista.Add(calificaciones);
                    }
                }
            }
            return lista;
        }
    }
}

using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class AlumnoAD
    {   // LLAMANDO A LA CONEXION DE LA BASE DE DATOS
        string conectionString = ConfigurationManager.ConnectionStrings["conx"].ConnectionString;
        //INSERTAR DATOS DATOS DEL FORMUALRIO POR MEDIO DEL PROCEDIMIENTO ALAMACENADO
        public int InsertarAlumnoAD(Alumno alumno)
        {
            int alumnoid = 0;
            // INSTANCIAMOS LA CONEXION A LA BD
            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                //LLAMAMOS AL SP DE LA BASE DE DATOS 
                using (SqlCommand sqlCommand = new SqlCommand("SP_INSERTAR_ALUMNO", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Primer_Nombre", alumno.Primer_Nombre);
                    sqlCommand.Parameters.AddWithValue("@Segundo_Nombre", alumno.Segundo_Nombre);
                    sqlCommand.Parameters.AddWithValue("@Primer_Apellido", alumno.Primer_Apellido);
                    sqlCommand.Parameters.AddWithValue("@Segundo_Apellido", alumno.Segundo_Apellido);
                    sqlCommand.Parameters.AddWithValue("@Telefono", alumno.Telefono);
                    sqlCommand.Parameters.AddWithValue("@Celular", alumno.Celular);
                    sqlCommand.Parameters.AddWithValue("@Direccion", alumno.Direccion);
                    sqlCommand.Parameters.AddWithValue("@Email", alumno.Email);
                    sqlCommand.Parameters.AddWithValue("@Fecha_de_Nacimiento", alumno.Fecha_Nacimiento);
                    sqlCommand.Parameters.AddWithValue("@Observaciones", alumno.Observaciones);
                    sqlConnection.Open();
                    alumnoid = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    sqlConnection.Close();
                }
                return alumnoid;
            }
        }

        public List<Alumno> ListarAlumnoAD()
        {
            List<Alumno> lista = new List<Alumno>();

            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("ListarAlumno", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Alumno alumno = new Alumno();
                        alumno.Id_Alumno = Convert.ToInt32(reader["Id_Alumno"]);
                        alumno.Primer_Nombre = Convert.ToString(reader["Primer_Nombre"]);
                        alumno.Segundo_Nombre = Convert.ToString(reader["Segundo_Nombre"]);
                        alumno.Primer_Apellido = Convert.ToString(reader["Primer_Apellido"]);
                        alumno.Segundo_Apellido = Convert.ToString(reader["Segundo_Apellido"]);
                        alumno.Telefono = Convert.ToString(reader["Telefono"]);
                        alumno.Celular = Convert.ToString(reader["Celular"]);
                        alumno.Direccion = Convert.ToString(reader["Direccion"]);
                        alumno.Email = Convert.ToString(reader["Email"]);
                        alumno.Fecha_Nacimiento = Convert.ToString(reader["Fecha_Nacimiento"]);
                        alumno.Observaciones = Convert.ToString(reader["Observaciones"]);
                        lista.Add(alumno);
                    }
                }
            }
            return lista;
        }

        // SECCION ACTUALIZAR ALUMNNOS
        public int ActualizarAlumnoAD(Alumno alumno)
        {
            int resultado = 0;

            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                // LLAMADO AL STORE PROCEDURE DE LA BASE DE DATOS PARA ACTUALIZAR UN REGISTRO DE ALUMNO
                using (SqlCommand sqlCommand = new SqlCommand("SP_ACTUALIZAR_ALUMNO", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", alumno.Id_Alumno);
                    sqlCommand.Parameters.AddWithValue("@PrimerNombre", alumno.Primer_Nombre);
                    sqlCommand.Parameters.AddWithValue("@SegundoNombre", alumno.Segundo_Nombre);
                    sqlCommand.Parameters.AddWithValue("@PrimerApellido", alumno.Primer_Apellido);
                    sqlCommand.Parameters.AddWithValue("@SegundoApellido", alumno.Segundo_Apellido);
                    sqlCommand.Parameters.AddWithValue("@Telefono", alumno.Telefono);
                    sqlCommand.Parameters.AddWithValue("@Celular", alumno.Celular);
                    sqlCommand.Parameters.AddWithValue("@Direccion", alumno.Direccion);
                    sqlCommand.Parameters.AddWithValue("@Email", alumno.Email);
                    sqlCommand.Parameters.AddWithValue("@FechadeNacimiento", alumno.Fecha_Nacimiento);
                    sqlCommand.Parameters.AddWithValue("@Observaciones", alumno.Observaciones);

                    sqlConnection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                return resultado;
            }
        }

        //SECCION PARA ELIMINAR UN REGISTRO 
        public int EliminarAlumnoAD(int id)
        {
            int resultado = 0;
            using (SqlConnection sqlConnection = new SqlConnection(conectionString))
            {
                // LLAMADO AL STORE PROCEDURE DE LA BASE DE DATOS PARA ELIMINAR UN REGISTRO DE ALUMNO
                using (SqlCommand sqlCommand = new SqlCommand("SP_ELIMINAR_ALUMNO", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    sqlConnection.Open();
                    resultado = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                return resultado;
            }
        }

    }
}

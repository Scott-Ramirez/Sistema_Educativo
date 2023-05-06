using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class AlumnoLN
    {
        public int InsertarAlumnoLN(Alumno alumno)
        {
            AlumnoAD alumnoAD = new AlumnoAD();

            return alumnoAD.InsertarAlumnoAD(alumno);
        }

        public List<Alumno> ListarAlumnosLN()
        {
            AlumnoAD alumnoAD = new AlumnoAD();
            return alumnoAD.ListarAlumnoAD();
        }

        public int ActualizarAlumnoLN(Alumno alumno)
        {
            AlumnoAD alumnoAD = new AlumnoAD();
            return alumnoAD.ActualizarAlumnoAD(alumno);
        }


        public int EliminarAlumnoLN(string idAlumno)
        {
            AlumnoAD alumnoAD = new AlumnoAD();
            return alumnoAD.EliminarAlumnoAD(Convert.ToInt32(idAlumno));

        }

    }
}

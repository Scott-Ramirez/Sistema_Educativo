 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calificaciones
    {
        public int IdEjercicio { get; set; }
        public int Id_Alumno { get; set; }
        public string Primer_Nombre { get; set; }   
        public string Nombre { get; set; }
        public Boolean Realizado { get; set; }
        public int Calificacion { get; set; }

        public Calificaciones()
        {
            Id_Alumno = 0;
            Primer_Nombre = "";
            Nombre = "";
            Realizado = false;
            Calificacion = 0;
        }
    }
}

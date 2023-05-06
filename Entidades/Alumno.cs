using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alumno
    {
        public int Id_Alumno { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Observaciones { get; set; }

        public Alumno()
        {
            Primer_Nombre = "";
            Segundo_Nombre = "";
            Primer_Apellido = "";
            Segundo_Apellido = "";
            Telefono = "";
            Celular = "";
            Direccion = "";
            Email = "";
            Fecha_Nacimiento = "";
            Observaciones = "";
        }
    }
}

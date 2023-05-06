using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class CalificacionLN
    {
        public int InsertarCalificacionesLN(Calificaciones calificaciones)
        {
            CalificacionAD calificacionAD = new CalificacionAD();

            return calificacionAD.InsertarCalificacionAD(calificaciones);
        }

        public List<Calificaciones> ListarCalificacionesLN()
        {        
            CalificacionAD calificacionAD = new CalificacionAD();
            return calificacionAD.ListarCalificacionesAD();
        }
    }
}

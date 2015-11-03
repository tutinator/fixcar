using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fixcar_daos;
using fixcar_entidades;

namespace fixcar_negocio
{
    public class GestorEstadosReparacion
    {
        public static List<EstadoReparacion> ObtenerTodos()
        {
            return EstadoReparacionDAO.ObtenerTodos();
        }
    }
}

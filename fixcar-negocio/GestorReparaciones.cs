using System;
using fixcar_daos;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_negocio
{
    public class GestorReparaciones
    {
        public static List<Reparacion> ObtenerTodas()
        {
            return ReparacionDAO.ObtenerTodas();
        }

        public static Reparacion ObtenerPorId(int idReparacion)
        {
            return ReparacionDAO.ObtenerPorId(idReparacion);
        }
        public static List<Reparacion> Obtener(int idVehiculo, int idEstado, decimal totalDesde, decimal totalHasta, string orden)
        {
            List<Reparacion> list = ReparacionDAO.Obtener(idVehiculo, idEstado, totalDesde, totalHasta, orden);
            return list;
        }
    }
}

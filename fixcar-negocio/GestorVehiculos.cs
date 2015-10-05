using System;
using fixcar_daos;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_negocio
{
    public class GestorVehiculos
    {
        public static List<Vehiculo> ObtenerTodos()
        {
            List<Vehiculo> list = VehiculoDAO.ObtenerTodos();
            return list;
        }

        public static Vehiculo ObtenerPorId(int id)
        {
            return VehiculoDAO.ObtenerPorId(id);
        }

        public static void InsertarVehiculo(Vehiculo v)
        {
            VehiculoDAO.InsertarVehiculo(v);
        }
        public static void ActualizarVehiculo(Vehiculo v)
        {
            VehiculoDAO.ActualizarVehiculo(v);
        }
    }
}

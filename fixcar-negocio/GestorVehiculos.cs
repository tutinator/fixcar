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

        public static void insertarVehiculo(Vehiculo v)
        {
            VehiculoDAO.insertarVehiculo(v);
        }
    }
}

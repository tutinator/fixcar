using System;
using fixcar_daos;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_negocio
{
    public class GestorClientes
    {
        public static List<Cliente> ObtenerTodos()
        {
            List<Cliente> list = ClienteDAO.ObtenerTodos();
            return list;
        }

        public static void insertarCliente(Cliente c)
        {
            ClienteDAO.InsertarCliente(c);
        }

        public static void actualizarCliente(Cliente c)
        {
            ClienteDAO.ActualizarCliente(c);
        }

        public static void eliminarCliente(Cliente c)
        {
            ClienteDAO.EliminarCliente(c);
        }

    }
}

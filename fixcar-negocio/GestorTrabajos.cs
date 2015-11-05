using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fixcar_entidades;
using fixcar_daos;

namespace fixcar_negocio
{
    public class GestorTrabajos
    {
        public static List<Trabajo> ObtenerTodos()
        {
            List<Trabajo> list = TrabajoDAO.ObtenerTodos();
            return list;
        }

        public static Trabajo ObtenerPorId(int idTrabajo)
        {
            Trabajo t = TrabajoDAO.ObtenerPorId(idTrabajo);
            return t;
        }
    }
}

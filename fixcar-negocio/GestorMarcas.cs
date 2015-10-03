using System;
using fixcar_daos;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_negocio
{
    public class GestorMarcas
    {
        public static List<Marca> ObtenerTodas()
        {
            List<Marca> list = MarcaDAO.ObtenerTodas();
            return list;
        }
    }
}

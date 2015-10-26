using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fixcar_entidades;
using fixcar_daos;

namespace fixcar_negocio
{
    public class GestorTipoDocumento
    {
        public static List<TipoDocumento> obtenerTodos()
        {
            List<TipoDocumento> list = TipoDocumentoDAO.obtenerTodos();
            return list;
        }
    }
}


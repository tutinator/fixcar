using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using fixcar_daos;

namespace fixcar_negocio
{
    public class GestorSesiones
    {
       
        public static bool estaAutenticado(string mail, string password)
        {
            return SesionDAO.estaAutenticado(mail, password);
        }
    }
}

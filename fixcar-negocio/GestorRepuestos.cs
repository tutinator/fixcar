﻿using System;
using fixcar_daos;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_negocio
{
    public class GestorRepuestos
    {
        public static List<Repuesto> ObtenerTodos()
        {
            return RepuestoDAO.ObtenerTodos();
        }
        public static Repuesto ObtenerPorId(int idRepuesto)
        {
            return RepuestoDAO.ObtenerPorId(idRepuesto);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    public class DetalleReparacion
    {
        public int idDetalleReparacion { get; set; }
        public Trabajo trabajo { get; set; }
        public int cantidad { get; set; }
        public Reparacion reparacion { get; set; }
    }
}

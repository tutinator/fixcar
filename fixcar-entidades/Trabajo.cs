using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    [Serializable()]
    public class Trabajo
    {
        public int idTrabajo { get; set; }
        public string nombreTrabajo { get; set; }
        public int duracion { get; set; }
        public decimal precioMO { get; set; }
    }
}

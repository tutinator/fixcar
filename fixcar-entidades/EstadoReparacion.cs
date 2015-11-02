using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    [Serializable()]
    public class EstadoReparacion
    {
        public int idEstado { get; set; }
        public string nombreEstado { get; set; }
    }
}

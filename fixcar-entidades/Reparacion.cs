using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    public class Reparacion
    {
        public int idReparacion { get; set; }
        public DateTime? fechaFin { get; set; }
        public Vehiculo vehiculo { get; set; }
        public EstadoReparacion estadoReparacion { get; set; }
        public decimal? totalMO { get; set; }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    [Serializable()]
    public class Factura
    {
        public int idFactura { get; set; }
        public int numeroFactura { get; set; }
        public DateTime fechaFactura { get; set; }
        public Reparacion reparacion { get; set; }
        public decimal? total { get; set; }     
    }
}

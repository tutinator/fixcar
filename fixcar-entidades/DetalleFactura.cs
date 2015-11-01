using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    [Serializable()]
    public class DetalleFactura
    {
        public int idDetalleFactura { get; set; }
        public Repuesto repuesto { get; set; }
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
        public Factura factura { get; set; }

    }
}

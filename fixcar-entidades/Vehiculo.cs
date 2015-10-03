using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    public class Vehiculo
    {
        public int idVehiculo { get; set; }
        public string dominio { get; set; }
        public int? km { get; set; }
        public Boolean pinturaDanada { get; set; }
        public int idMarca { get; set; }
        public int idCliente { get; set; }
        public int ano { get; set; }

        
    }
}

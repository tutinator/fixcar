using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    [Serializable()]
    public class Vehiculo
    {
        public int idVehiculo { get; set; }
        public string dominio { get; set; }
        public int? km { get; set; }
        public Boolean pinturaDanada { get; set; }
        public Marca marca { get; set; }
        public Cliente cliente { get; set; }
        public int ano { get; set; }

        
    }
}

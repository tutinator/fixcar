using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    class Clientes
    {
        private int idCliente { get; set; }
        private string apellido{ get; set; }
        private string nombre { get; set; }
        private TiposDocumento tipoDocumento { get; set; }
        private int numeroDocumento { get; set; }
        private DateTime fechaNacimiento { get; set; }
        private bool genero { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    [Serializable()]
    public class TipoDocumento
    {
        public int idTipoDocumento { get; set; }
        public string nombreTipoDocumento { get; set; }
    }
}

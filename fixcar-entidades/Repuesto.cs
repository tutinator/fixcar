using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    public class Repuesto
    {
        public int idRepuesto { get; set; }
        public string nombreRepuesto { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
    }
}

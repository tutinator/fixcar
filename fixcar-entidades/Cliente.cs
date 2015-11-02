using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_entidades
{
    [Serializable()]
    public class Cliente
    {
        public int idCliente { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public TipoDocumento tipoDocumento { get; set; }
        public int numeroDocumento { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool? genero { get; set; }
        public string nombreCompleto { get; set; }
        public string generoString { get; set; }

        public void completarNombre()
        {
            nombreCompleto = apellido + ", " + nombre;
        }

        public void generarString()
        {
            if (genero == true) generoString = "Femenino";
            else
            {
                if (genero == false) generoString = "Masculino";
                else generoString = "";
            }
            
        }

    }

    

}

using System;
using fixcar_daos;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_negocio
{
    public class GestorFacturas
    {
        public static List<Factura> Obtener(DateTime? fechaDesde, DateTime? fechaHasta, int idCliente, decimal totalDesde, decimal totalHasta)
        {
            List<Factura> list = FacturaDAO.Obtener(fechaDesde, fechaHasta, idCliente, totalDesde, totalHasta);
            return list;
        }

        //public static Factura ObtenerPorId(int id)
        //{
        //    //return FacturaDAO.ObtenerPorId(id);
        //}

        public static void InsertarFactura(Factura f, List<DetalleFactura> listaDetalles)
        {
            FacturaDAO.InsertarFactura(f, listaDetalles);
        }

        public static int ObtenerNumeroMaximo()
        {
            return FacturaDAO.ObtenerMaximoNumero();
        }
    }
}

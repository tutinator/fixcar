using System;
using System.Collections.Generic;
using fixcar_entidades;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace fixcar_daos
{
    public class DetalleFacturaDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static void InsertarDetalleFactura(DetalleFactura df, SqlTransaction tran, SqlConnection con)
        {            
            try
            {               
                string sql = "INSERT INTO DetallesFacturas (idRepuesto, cantidad, subtotal, idFactura) VALUES (@idRepuesto, @cantidad, @subtotal, @idFactura)";
                sql += "; UPDATE Repuestos SET stock = stock - @c WHERE idRepuesto = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@idRepuesto", df.repuesto.idRepuesto);
                cmd.Parameters.AddWithValue("@id", df.repuesto.idRepuesto);
                cmd.Parameters.AddWithValue("@cantidad", df.cantidad);
                cmd.Parameters.AddWithValue("@subtotal", df.subtotal);
                cmd.Parameters.AddWithValue("@c", df.cantidad);
                cmd.Parameters.AddWithValue("@idFactura", df.factura.idFactura);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error al insertar detalle factura: " + e.Message);
            }
            
        }
    }
}

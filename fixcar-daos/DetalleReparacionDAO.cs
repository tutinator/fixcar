using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fixcar_entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace fixcar_daos
{
    public class DetalleReparacionDAO
    {
       private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static void InsertarDetalleReparacion(DetalleReparacion dr, SqlTransaction tran, SqlConnection con)
        {
            try
            {
                string sql = "INSERT INTO DetallesReparaciones (idTrabajo, cantidad, idReparacion) VALUES (@idTrabajo, @cantidad, @idReparacion)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@idTrabajo", dr.trabajo.idTrabajo);
                cmd.Parameters.AddWithValue("@cantidad", dr.cantidad);
                cmd.Parameters.AddWithValue("@idReparacion", dr.reparacion.idReparacion);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error al insertar detalle reparacion: " + e.Message);
            }

        }
    
    }
}

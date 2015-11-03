using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using fixcar_entidades;

namespace fixcar_daos
{
    public class EstadoReparacionDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static List<EstadoReparacion> ObtenerTodos()
        {
            List<EstadoReparacion> list = new List<EstadoReparacion>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            string consulta = "SELECT idEstado, nombreEstado FROM EstadosReparacion";
            cmd.CommandText = consulta;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                EstadoReparacion e = new EstadoReparacion();
                e.idEstado = (int)dr["idEstado"];
                e.nombreEstado = dr["nombreEstado"].ToString();
                list.Add(e);
            }

            dr.Close();
            cn.Close();
            return list;
        }
    }
}

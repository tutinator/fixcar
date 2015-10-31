using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_daos
{
    public class RepuestoDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static List<Repuesto> ObtenerTodos()
        {
            List<Repuesto> list = new List<Repuesto>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            string consulta = "SELECT idRepuesto, nombreRepuesto, precio, stock FROM Repuestos";
            cmd.CommandText = consulta;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Repuesto r = new Repuesto();
                r.idRepuesto = (int)dr["idRepuesto"];
                r.nombreRepuesto = dr["nombreRepuesto"].ToString();
                r.precio = (decimal)dr["precio"];
                r.stock = (int)dr["stock"];
                list.Add(r);
            }

            dr.Close();
            cn.Close();
            return list;
        }

    }
}


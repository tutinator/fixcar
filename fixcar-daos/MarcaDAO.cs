
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
    public class MarcaDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static List<Marca> ObtenerTodas()
        {
            List<Marca> list = new List<Marca>();
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            string consulta = "SELECT idMarca, nombreMarca FROM Marcas";
            cmd.CommandText = consulta;

            SqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                Marca m = new Marca();
                m.idMarca = (int)dr["idMarca"];
                m.nombreMarca = dr["nombreMarca"].ToString();
                list.Add(m);                
            }

            dr.Close();
            cn.Close();
            return list;
        }

    }
}

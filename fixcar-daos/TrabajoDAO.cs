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
    public class TrabajoDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static List<Trabajo> ObtenerTodos()
        {
            List<Trabajo> list = new List<Trabajo>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena;
            try {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                string consulta = "SELECT idTrabajo, nombreTrabajo, duracion, precioMO FROM Trabajos ORDER BY nombreTrabajo ASC";
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Trabajo t = new Trabajo();
                    t.idTrabajo = (int)dr["idTrabajo"];
                    t.nombreTrabajo = dr["nombreTrabajo"].ToString();
                    t.duracion = (int)dr["duracion"];
                    t.precioMO = (decimal)dr["precioMO"];
                    list.Add(t);
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }
            return list;
        }



        public static Trabajo ObtenerPorId(int idTrabajo)
        {
            Trabajo t = new Trabajo();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena;
            try {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                string consulta = "SELECT idTrabajo, nombreTrabajo, duracion, precioMO FROM Trabajos WHERE idTrabajo = @idTrabajo";
                cmd.CommandText = consulta;
                cmd.Parameters.AddWithValue("@idTrabajo", idTrabajo);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    t.idTrabajo = (int)dr["idTrabajo"];
                    t.nombreTrabajo = dr["nombreTrabajo"].ToString();
                    t.duracion = (int)dr["duracion"];
                    t.precioMO = (decimal)dr["precioMO"];
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }
            return t;
        }
    }
}

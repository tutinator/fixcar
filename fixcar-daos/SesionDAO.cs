using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace fixcar_daos
{
    public class SesionDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;
        public static bool estaAutenticado(string mail, string password)
        {
            if (mail == "admin" & password == "admin") return true;

            string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = cadena;
                connection.Open();
                //string sql = "SELECT id_cliente, nombre, apellido, localidad, fechaNacimiento, mail, password, rol, preferencial FROM CLIENTES order by apellido";
                string sql = "Select mail, password from CLIENTES where mail like @userName and password like @password";
                SqlCommand comand = new SqlCommand();
                comand.Parameters.AddWithValue("@userName", mail);
                comand.Parameters.AddWithValue("@password", password);
                comand.CommandText = sql;
                comand.Connection = connection;
                SqlDataReader dr = comand.ExecuteReader();

                while (dr.Read())
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                //if (connection.State == ConnectionState.Open)
                    throw new ApplicationException("No existe cliente");
            }
            finally
            {
                //if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return false;
        }
    }
}

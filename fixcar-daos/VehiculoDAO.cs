using System;
using System.Collections.Generic;
using fixcar_entidades;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_daos
{
    public class VehiculoDAO
    {
        public static List<Vehiculo> ObtenerTodos()
        {
            List<Vehiculo> list = new List<Vehiculo>();
            string cadenaConexion = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadenaConexion;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            string consulta = "SELECT idVehiculo, dominio, km, pinturaDanada, idMarca, idCliente, ano FROM Vehiculos";
            cmd.CommandText = consulta;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Vehiculo m = new Vehiculo();
                m.idVehiculo = (int)dr["idVehiculo"];
                m.dominio = dr["dominio"].ToString();
                m.km = (int?)dr["km"];
                m.pinturaDanada = (Boolean)dr["pinturaDanada"];
                m.idMarca = (int)dr["idMarca"];
                m.idCliente = (int)dr["idCliente"];                
                m.ano = (int)dr["ano"];
                
                list.Add(m);
            }

            dr.Close();
            cn.Close();
            return list;
        }
    }
}

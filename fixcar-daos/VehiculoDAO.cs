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

            string consulta = "SELECT V.idVehiculo, V.dominio, V.km, pinturaDanada, V.idMarca, M.nombreMarca, V.idCliente, C.nombre, C.apellido, V.ano FROM Vehiculos V JOIN Marcas M ON V.idMarca = M.idMarca JOIN Clientes C ON C.idCliente = V.idCliente";
            cmd.CommandText = consulta;

            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                Vehiculo v = new Vehiculo();
                v.idVehiculo = (int)dr["idVehiculo"];
                v.dominio = dr["dominio"].ToString();
                v.km = (int?)dr["km"];
                v.pinturaDanada = (Boolean)dr["pinturaDanada"];
                v.ano = (int)dr["ano"];

                Marca m = new Marca();
                m.idMarca = (int)dr["idMarca"];
                m.nombreMarca = dr["nombreMarca"].ToString();                
                
                v.marca = m;

                Cliente c = new Cliente();
                c.idCliente = (int)dr["idCliente"];
                c.apellido = dr["apellido"].ToString();
                c.nombre = dr["nombre"].ToString();
                c.completarNombre();
                v.cliente = c;

                list.Add(v);
            }

            dr.Close();
            cn.Close();
            return list;
        }

        public static void insertarVehiculo(Vehiculo v)
        {
            string cadena = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "INSERT INTO Vehiculos (dominio, km, pinturaDanada, idMarca, idCliente, ano) VALUES (@dominio, @km, @pinturaDanada, @idMarca, @idCliente, @ano)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@dominio", v.dominio);
                cmd.Parameters.AddWithValue("@km", v.km);
                cmd.Parameters.AddWithValue("@pinturaDanada", v.pinturaDanada);
                cmd.Parameters.AddWithValue("@idMarca", v.marca.idMarca);
                cmd.Parameters.AddWithValue("@idCliente", v.cliente.idCliente);
                cmd.Parameters.AddWithValue("@ano", v.ano);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error al insertar cliente ");
            }
            finally
            {
                con.Close();
            }
        }
    }
}

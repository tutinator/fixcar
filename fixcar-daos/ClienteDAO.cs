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
    public class ClienteDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static List<Cliente> ObtenerTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            
            
            SqlConnection con = new SqlConnection(cadena);            
            try
            {
                con.Open();
                string sql = "SELECT c.idCliente, c.apellido, c.nombre, t.idTipoDocumento, t.nombreTipoDocumento, c.numeroDocumento, c.fechaNacimiento, c.genero FROM Clientes c JOIN TiposDocumento T ON (c.idTipoDocumento = t.idTipoDocumento)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cliente c = new Cliente();
                    c.idCliente = (int)dr["idCliente"];
                    c.apellido = dr["apellido"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.numeroDocumento = (int)dr["numeroDocumento"];
                    c.fechaNacimiento = DateTime.Parse(dr["fechaNacimiento"].ToString());
                    TipoDocumento tipoDoc = new TipoDocumento();
                    tipoDoc.idTipoDocumento = (int)dr["idTipoDocumento"];
                    tipoDoc.nombreTipoDocumento = dr["nombreTipoDocumento"].ToString();
                    c.tipoDocumento = tipoDoc;
                    c.genero = (bool?)dr["genero"];
                    c.generarString();
                    c.completarNombre();

                    listaClientes.Add(c);
                }
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Surgió un porblema al obtener clientes");
            }
            finally
            {
                con.Close();
            }
            return listaClientes;
        }

        public static void InsertarCliente(Cliente c)
        {
            
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "INSERT INTO Clientes (apellido, nombre, idTipoDocumento,  numeroDocumento, fechaNacimiento, genero) VALUES (@apellido,@nombre, @idTipoDocumento,  @numeroDocumento, @fechaNacimiento, @genero)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;

                cmd.Parameters.AddWithValue("@apellido", c.apellido);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@idTipoDocumento", c.tipoDocumento.idTipoDocumento);
                cmd.Parameters.AddWithValue("@numeroDocumento", c.numeroDocumento);
                cmd.Parameters.AddWithValue("@fechaNacimiento", c.fechaNacimiento);
                cmd.Parameters.AddWithValue("@genero", c.genero);
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

        public static void ActualizarCliente(Cliente c)
        {
            
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "UPDATE Clientes SET apellido = @apellido, nombre = @nombre, idTipoDocumento = @idTipoDocumento,  numeroDocumento = @numeroDocumento, fechaNacimiento=@fechaNacimiento, genero=@genero WHERE idCliente = @idCliente";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
                cmd.Parameters.AddWithValue("@apellido", c.apellido);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@idTipoDocumento", c.tipoDocumento.idTipoDocumento);
                cmd.Parameters.AddWithValue("@numeroDocumento", c.numeroDocumento);
                cmd.Parameters.AddWithValue("@fechaNacimiento", c.fechaNacimiento);
                cmd.Parameters.AddWithValue("@genero", c.genero);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error al actualizar Cliente");
            }
            finally
            {
                con.Close();
            }
        }

        public static void EliminarCliente(Cliente c)
        {
        
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "DELETE FROM Clientes WHERE idCliente = @idCliente)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@idCliente", c.idCliente);
                cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error al eliminar Cliente");
            }
            finally
            {
                con.Close();
            }
        }

        public static Cliente ObtenerPorId(int id)
        {
            Cliente c = new Cliente();
          
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cadena;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            string consulta = "SELECT c.idCliente, c.apellido, c.nombre, t.idTipoDocumento, t.nombreTipoDocumento, c.numeroDocumento, c.fechaNacimiento, c.genero FROM Clientes c JOIN TiposDocumento T ON (c.idTipoDocumento = t.idTipoDocumento) WHERE c.idCliente = @idCliente"; 
            cmd.CommandText = consulta;
            cmd.Parameters.AddWithValue("@idCliente", id);

            SqlDataReader dr = cmd.ExecuteReader();
            try { 
            while (dr.Read())
            {

                c.idCliente = (int)dr["idCliente"];
                c.apellido = dr["apellido"].ToString();
                c.nombre = dr["nombre"].ToString();
                c.numeroDocumento = (int)dr["numeroDocumento"];
                c.fechaNacimiento= DateTime.Parse(dr["fechaNacimiento"].ToString());
                c.genero = (bool?) dr["genero"];
                TipoDocumento t = new TipoDocumento();
                t.idTipoDocumento = (int)dr["idTipoDocumento"];
                t.nombreTipoDocumento = dr["nombreTipoDocumento"].ToString();
                c.tipoDocumento = t;

            }
            }catch (SqlException e)
            {
                throw new ApplicationException("Error al obtener cliente");
            }finally
            {
                dr.Close();
                cn.Close();
            }

            return c;
        }

    }
}

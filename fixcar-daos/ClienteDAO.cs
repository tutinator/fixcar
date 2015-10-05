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
        public static List<Cliente> ObtenerTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();            
            string cadena = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
                    c.genero = (bool)dr["genero"];
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
            string cadena = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
            string cadena = "Data Source='Franco-HP\\sqlexpress';Initial Catalog=fixcardb;Persist Security Info=True;User ID=sa;Password=sa";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "UPDATE Clientes SET apellido = @apellido, nombre = @nombre, idTipoDocumento = @idTipoDocumento,  numeroDocumento = @idTipoDocumento, fechaNacimiento=@fechaNacimiento, genero=@genero WHERE idCliente = @idCliente)";

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
                throw new ApplicationException("Error al actualizar Cliente");
            }
            finally
            {
                con.Close();
            }
        }

        public static void EliminarCliente(Cliente c)
        {
            string cadena = "Data Source='Franco-HP\\sqlexpress';Initial Catalog=fixcardb;Persist Security Info=True;User ID=sa;Password=sa";
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

    }
}

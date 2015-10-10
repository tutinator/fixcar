using System;
using System.Collections.Generic;
using fixcar_entidades;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixcar_daos
{
    public class TipoDocumentoDAO
    {

        public static List<TipoDocumento> obtenerTodos()
        {
            List<TipoDocumento> listaTiposDocumento = new List<TipoDocumento>();
            string cadena = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                string sql = "SELECT idTipoDocumento, nombreTipoDocumento FROM TiposDocumento";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TipoDocumento t = new TipoDocumento();
                    t.idTipoDocumento = (int)dr["idTipoDocumento"];
                    t.nombreTipoDocumento = dr["nombreTipoDocumento"].ToString();
                    listaTiposDocumento.Add(t);
                }
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Surgió un porblema al obtener tipos de documento");
            }
            finally
            {
                con.Close();
            }
            return listaTiposDocumento;
        }


    
    
        public static void insertarTipoDocumento(TipoDocumento t)
    {

            string cadena = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(cadena);
        try
        {
            con.Open();
            string sql = "INSERT INTO TipoDocumento (nombreTipoDocumento) VALUES (@nombreTipoDocumento)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@nombreTipoDocumento", t.nombreTipoDocumento);
            cmd.ExecuteNonQuery();

        }
        catch (SqlException e)
        {
            throw new ApplicationException("Error al insertar Tipo de Documento ");
        }
        finally
        {
            con.Close();
        }
    }

    public static void eliminarTipoDocumento(TipoDocumento t)
    {

            string cadena = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(cadena);
        try
        {
            con.Open();
            string sql = "DELETE FROM TipoDocumento WHERE idTipoDocumento = @idTipoDocumento)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@idTipoDocumento", t.idTipoDocumento);
            cmd.ExecuteNonQuery();

        }
        catch (SqlException e)
        {
            throw new ApplicationException("Error al eliminar Tipo de Documento ");
        }
        finally
        {
            con.Close();
        }
    }

    public static void actualizarTipoDocumento(TipoDocumento t)
    {
            string cadena = "Data Source=TANGO-PC-00\\SQLEXPRESS;Initial Catalog=fixcardb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(cadena);
        try
        {
            con.Open();
            string sql = "UPDATE TipoDocumento SET nombreTipoDocumento = @nombreTipoDocumento WHERE idTipoDocumento = @idTipoDocumento";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@nombreTipoDocumento", t.nombreTipoDocumento);
            cmd.Parameters.AddWithValue("@idTipoDocumento", t.idTipoDocumento);
            cmd.ExecuteNonQuery();

        }
        catch (SqlException e)
        {
            throw new ApplicationException("Error al actualizar Tipo de Documento ");
        }
        finally
        {
            con.Close();
        }
    }
}
}

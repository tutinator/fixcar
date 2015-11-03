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
    public class ReparacionDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static List<Reparacion> ObtenerTodas()
        {
            List<Reparacion> listaReparaciones = new List<Reparacion>();
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string sql = "SELECT Vehiculos.dominio, Clientes.apellido, Clientes.nombre, Reparaciones.idReparacion, Reparaciones.totalMO, EstadosReparacion.nombreEstado";
                sql += " FROM Reparaciones INNER JOIN Vehiculos ON Reparaciones.idVehiculo = Vehiculos.idVehiculo INNER JOIN";
                sql += " EstadosReparacion ON Reparaciones.idEstado = EstadosReparacion.idEstado INNER JOIN Clientes ON Vehiculos.idCliente = Clientes.idCliente";
                sql += " WHERE Reparaciones.idEstado = @idEstado";
                cmd.Parameters.AddWithValue("@idEstado", 3);

                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Reparacion r = new Reparacion();
                    Vehiculo v = new Vehiculo();
                    Cliente c = new Cliente();
                    EstadoReparacion e = new EstadoReparacion();

                    r.idReparacion = (int)dr["idReparacion"];
                    v.dominio = dr["dominio"].ToString();
                    c.apellido = dr["apellido"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.completarNombre();
                    r.totalMO = (decimal)dr["totalMO"];
                    e.nombreEstado = dr["nombreEstado"].ToString();

                    r.estadoReparacion = e;
                    v.cliente = c;
                    r.vehiculo = v;
                   
                    listaReparaciones.Add(r);
                }
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Surgió un porblema al obtener reparaciones");
            }
            finally
            {
                con.Close();
            }
            return listaReparaciones;
        }
        public static Reparacion ObtenerPorId(int idReparacion)
        {
            Reparacion r = new Reparacion();
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string sql = "SELECT Vehiculos.dominio, Clientes.apellido, Clientes.nombre, Reparaciones.idReparacion, Reparaciones.totalMO, EstadosReparacion.nombreEstado";
                sql += " FROM Reparaciones INNER JOIN Vehiculos ON Reparaciones.idVehiculo = Vehiculos.idVehiculo INNER JOIN";
                sql += " EstadosReparacion ON Reparaciones.idEstado = EstadosReparacion.idEstado INNER JOIN Clientes ON Vehiculos.idCliente = Clientes.idCliente";
                sql += " WHERE Reparaciones.idEstado = @idEstado AND Reparaciones.idReparacion = @idReparacion";
                cmd.Parameters.AddWithValue("@idEstado", 3);
                cmd.Parameters.AddWithValue("@idReparacion", idReparacion);

                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    Vehiculo v = new Vehiculo();
                    Cliente c = new Cliente();
                    EstadoReparacion e = new EstadoReparacion();

                    r.idReparacion = (int)dr["idReparacion"];
                    v.dominio = dr["dominio"].ToString();
                    c.apellido = dr["apellido"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.completarNombre();
                    r.totalMO = (decimal)dr["totalMO"];
                    e.nombreEstado = dr["nombreEstado"].ToString();

                    r.estadoReparacion = e;
                    v.cliente = c;
                    r.vehiculo = v;

                  
                }
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Surgió un porblema al obtener reparaciones");
            }
            finally
            {
                con.Close();
            }
            return r;
        }

        public static void Facturar(int idReparacion, SqlConnection con, SqlTransaction tran)
        {

            try
            {
                
                string sql = "UPDATE Reparaciones SET idEstado = @idEstado WHERE idReparacion = @idReparacion";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@idReparacion", idReparacion);
                cmd.Parameters.AddWithValue("@idEstado", 4);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Error al actualizar reparacion: " + e.Message);
            }
            
        }

    }
    }


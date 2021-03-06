﻿using System;
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

        public static List<Reparacion> Obtener(int idVehiculo, int idEstado, decimal totalDesde, decimal totalHasta, string orden)
        {
            List<Reparacion> listaReparaciones = new List<Reparacion>();
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string sql = "SELECT Reparaciones.idReparacion, Vehiculos.dominio, Clientes.apellido, Clientes.nombre, EstadosReparacion.nombreEstado, Reparaciones.fechaFin, Reparaciones.totalMO";
                //Facturas.numeroFactura, Facturas.fechaFactura, Vehiculos.dominio, Clientes.apellido, Clientes.nombre, Clientes.numeroDocumento, Reparaciones.totalMO, Facturas.total";
                sql += " FROM Reparaciones JOIN Vehiculos ON Reparaciones.idVehiculo = Vehiculos.idVehiculo JOIN Clientes ON Vehiculos.idCliente = Clientes.idCliente ";
                sql += "JOIN EstadosReparacion ON Reparaciones.idEstado = EstadosReparacion.idEstado";

                string where = "";

                if (idVehiculo != 0)
                {
                    where += " AND (Vehiculos.idVehiculo = @idVehiculo)";
                    cmd.Parameters.AddWithValue("@idVehiculo", idVehiculo);
                }
                if (idEstado != 0)
                {
                    where += " AND (EstadosReparacion.idEstado = @idEstado)";
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);
                }

                if (totalDesde > -1 && totalHasta > -1)
                {
                    where += " AND (Reparaciones.totalMO BETWEEN @totalDesde AND @totalHasta)";
                    cmd.Parameters.AddWithValue("@totalDesde", totalDesde);
                    cmd.Parameters.AddWithValue("@totalHasta", totalHasta);
                }
                else
                {
                    if (totalDesde > -1)
                    {
                        where += " AND (Reparaciones.totalMO > @totalDesde)";
                        cmd.Parameters.AddWithValue("@totalDesde", totalDesde);
                    }
                    else
                    {
                        if (totalHasta > -1)
                        {
                            where += " AND (Reparaciones.totalMO < @totalHasta)";
                            cmd.Parameters.AddWithValue("@totalHasta", totalHasta);
                        }
                    }
                }

                if (where != "")
                {
                    sql += " WHERE ";
                    sql += where.Substring(5);
                }
                if(orden != "")
                {
                    sql += " ORDER BY " + orden;
                }
                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    Reparacion r = new Reparacion();
                    Vehiculo v = new Vehiculo();
                    Cliente c = new Cliente();
                    EstadoReparacion e = new EstadoReparacion();

                    v.dominio = dr["dominio"].ToString();
                    c.apellido = dr["apellido"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.completarNombre();
                    e.nombreEstado = dr["nombreEstado"].ToString();
                    r.idReparacion = (int)dr["idReparacion"];
                    if(dr["fechaFin"] == DBNull.Value)
                    {
                        r.fechaFin = null;
                    }
                    else
                        r.fechaFin = DateTime.Parse(dr["fechaFin"].ToString());
                    r.totalMO = (decimal)dr["totalMO"];
                    

                    v.cliente = c;
                    r.vehiculo = v;
                    r.estadoReparacion = e;

                    listaReparaciones.Add(r);
                }
            }
            catch(SqlException e) {
                throw e;
                    //new ApplicationException("Surgió un porblema al obtener facturas");
            }
            finally
            {
                con.Close();
            }

            return listaReparaciones;
        }

        public static void InsertarReparacion(Reparacion r, List<DetalleReparacion> listaDetalles)
        {

            SqlConnection con = new SqlConnection(cadena);

            con.Open();
            SqlTransaction tran = con.BeginTransaction();
            //Insertamos la factura primero
            string sql = "INSERT INTO Reparaciones (fechaFin, idVehiculo, idEstado, totalMO) VALUES (@fechaFin, @idVehiculo, @idEstado, @totalMO); SELECT @@Identity";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.Transaction = tran;

            cmd.Parameters.AddWithValue("@fechaFin", r.fechaFin);
            cmd.Parameters.AddWithValue("@idVehiculo", r.vehiculo.idVehiculo);
            cmd.Parameters.AddWithValue("@idEstado", r.estadoReparacion.idEstado);
            cmd.Parameters.AddWithValue("@totalMO", r.totalMO);

            try
            {
                int idReparacion = Convert.ToInt32(cmd.ExecuteScalar());
                r.idReparacion = idReparacion;

                //Insertamos los detalles luego
                foreach (var dr in listaDetalles)
                {
                    dr.reparacion= r;
                    DetalleReparacionDAO.InsertarDetalleReparacion(dr, tran, con);
                }

                ////Marcar como facturada la reparacion
                //ReparacionDAO.Facturar(f.reparacion.idReparacion, con, tran);

                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw new ApplicationException("Error al insertar factura: " + e.Message);
            }


            finally
            {
                con.Close();
            }
        }

        public static int ObtenerMaximoNumero()
        {
            int numeroMaximo = 0;
            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string sql = "SELECT MAX(idReparacion) FROM Reparaciones";

                cmd.CommandText = sql;
                cmd.Connection = con;
                numeroMaximo = (int)cmd.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Surgió un porblema al obtener ultima reparación");
            }
            finally
            {
                con.Close();
            }
            return numeroMaximo;
        }

    }


    }


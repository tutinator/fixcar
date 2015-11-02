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
    public class FacturaDAO
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["StringConexionActiva"].ConnectionString;

        public static List<Factura> Obtener(DateTime? fechaDesde, DateTime? fechaHasta, int idCliente, decimal totalDesde, decimal totalHasta)
        {
            List<Factura> listaFacturas = new List<Factura>();


            SqlConnection con = new SqlConnection(cadena);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                string sql = "SELECT Facturas.numeroFactura, Facturas.fechaFactura, Vehiculos.dominio, Clientes.apellido, Clientes.nombre, Clientes.numeroDocumento, Reparaciones.totalMO, Facturas.total";
                sql += " FROM Reparaciones JOIN Facturas ON Reparaciones.idReparacion = Facturas.idReparacion JOIN Vehiculos ON Reparaciones.idVehiculo = Vehiculos.idVehiculo JOIN Clientes ON Vehiculos.idCliente = Clientes.idCliente";

                string where = "";

                if (fechaDesde != null && fechaHasta != null)
                {
                    where += " AND (Facturas.fechaFactura BETWEEN @fechaDesde AND @fechaHasta)";
                    cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                }
                else
                {
                    if (fechaDesde != null)
                    {
                        where += " AND (Facturas.fechaFactura > @fechaDesde)";
                        cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    }
                    else
                    {
                        if (fechaHasta != null)
                        {
                            where += " AND (Facturas.fechaFactura < @fechaHasta)";
                            cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                        }
                    }
                }

                if (idCliente != 0)
                {
                    where += " AND (Clientes.idCliente = @idCliente)";
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                }

                if (totalDesde > -1 && totalHasta > -1)
                {
                    where += " AND (Facturas.total BETWEEN @totalDesde AND @totalHasta)";
                    cmd.Parameters.AddWithValue("@totalDesde", totalDesde);
                    cmd.Parameters.AddWithValue("@totalHasta", totalHasta);
                }
                else
                {
                    if (totalDesde > -1)
                    {
                        where += " AND (Facturas.total > @totalDesde)";
                        cmd.Parameters.AddWithValue("@totalDesde", totalDesde);
                    }
                    else
                    {
                        if (totalHasta > -1)
                        {
                            where += " AND (Facturas.total < @totalHasta)";
                            cmd.Parameters.AddWithValue("@totalHasta", totalHasta);
                        }
                    }
                }

                if (where != "")
                {
                    sql += " WHERE ";
                    sql += where.Substring(5);
                }

                cmd.CommandText = sql;
                cmd.Connection = con;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Factura f = new Factura();
                    Reparacion r = new Reparacion();
                    Vehiculo v = new Vehiculo();
                    Cliente c = new Cliente();

                    f.numeroFactura = (int)dr["numeroFactura"];
                    f.fechaFactura = DateTime.Parse(dr["fechaFactura"].ToString());
                    v.dominio = dr["dominio"].ToString();
                    c.apellido = dr["apellido"].ToString();
                    c.nombre = dr["nombre"].ToString();
                    c.numeroDocumento = (int)dr["numeroDocumento"];
                    c.completarNombre();
                    r.totalMO = (decimal)dr["totalMO"];
                    f.total = (decimal)dr["total"];

                    v.cliente = c;
                    r.vehiculo = v;
                    f.reparacion = r;


                    listaFacturas.Add(f);
                }
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Surgió un porblema al obtener facturas");
            }
            finally
            {
                con.Close();
            }
            return listaFacturas;
        }

        public static void InsertarFactura(Factura f, List<DetalleFactura> listaDetalles)
        {

            SqlConnection con = new SqlConnection(cadena);
            
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                //Insertamos la factura primero
                string sql = "INSERT INTO Facturas (numeroFactura, fechaFactura, idReparacion, total) VALUES (@numeroFactura, @fechaFactura, @idReparacion, @total); SELECT @@Identity";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = con;
                cmd.Transaction = tran;

                cmd.Parameters.AddWithValue("@numeroFactura", f.numeroFactura);
                cmd.Parameters.AddWithValue("@fechaFactura", f.fechaFactura);
                cmd.Parameters.AddWithValue("@idReparacion", f.reparacion.idReparacion);
                cmd.Parameters.AddWithValue("@total", f.total);

            try
            {
                int idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                f.idFactura = idFactura;

                //Insertamos los detalles luego
                foreach (var df in listaDetalles)
                {
                    df.factura = f;
                    DetalleFacturaDAO.InsertarDetalleFactura(df, tran, con);
                }

                //Marcar como facturada la reparacion
                ReparacionDAO.Facturar(f.reparacion.idReparacion, con, tran);

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
                string sql = "SELECT MAX(numeroFactura) FROM Facturas";

                cmd.CommandText = sql;
                cmd.Connection = con;
                numeroMaximo = (int)cmd.ExecuteScalar();
            }
            catch (SqlException e)
            {
                throw new ApplicationException("Surgió un porblema al obtener facturas");
            }
            finally
            {
                con.Close();
            }
            return numeroMaximo;
        }
    }
}



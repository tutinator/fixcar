using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fixcar_entidades;
using fixcar_negocio;

public partial class RegistrarReparacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Inicio();
        }

    }

    private void Inicio()
    {
        
        btnAgregarTrabajos.Enabled = false;
        btnGuardar.Enabled = false;
        ViewState["fechaFin"] = DBNull.Value;
        ViewState["totalReparacion"] = 0;
        ViewState["detallesReparacion"] = new List<DetalleReparacion>();
        ViewState["idVehiculo"] = null;
        CargarDDLS();
        CargarGrillas();
        
        txtCantidadDetalles.Text = string.Empty;
        //txtCantidadRepuestos.Text = string.Empty;
        txtCliente.Text = string.Empty;
        txtDominio.Text = string.Empty;
        //txtMO.Text = string.Empty;
        //txtSubTotalDetalles.Text = string.Empty;
        txtMarca.Text = string.Empty;
        txtFechaFin.Text = string.Empty;
        txtTotalReparacion.Text = string.Empty;
    }

    private void CargarDDLS()
    {
        CargarDDLTrabajos();
    }

    private void CargarDDLTrabajos()
    {
        List<Trabajo> lista = GestorTrabajos.ObtenerTodos();
        ddlTrabajos.DataSource = lista;
        ddlTrabajos.DataTextField = "nombreTrabajo";
        ddlTrabajos.DataValueField = "idTrabajo";
        ddlTrabajos.DataBind();
        ddlTrabajos.Items.Insert(0, new ListItem("Seleccionar", "0"));
        ddlTrabajos.SelectedIndex = 0;
    }

    private void CargarGrillas()
    {
        CargarGrillaVehiculos();
       // CargarGrillaTrabajos();
    }

    private void CargarGrillaVehiculos()
    {
        string orden = "dominio DESC";
        if (ViewState["OrdenGvVehiculos"] != null)
        {
            orden = ViewState["OrdenGvVehiculos"].ToString();
        }
        List<Vehiculo> listaVehiculos = GestorVehiculos.ObtenerTodos(orden);
        gvVehiculos.DataSource = listaVehiculos;
        gvVehiculos.DataBind();
    }

    private void CargarGrillaTrabajos()
    {
        if (ViewState["detallesReparacion"] == null) ViewState["detallesReparacion"] = new List<DetalleReparacion>();
        List<DetalleReparacion> listaDetalles = (List<DetalleReparacion>)ViewState["detallesReparacion"];
        gvDetallesReparacion.DataSource = listaDetalles;
        gvDetallesReparacion.DataBind();
        if (listaDetalles.Count == 0) alertaNoTrabajos.Visible = true;
        else alertaNoTrabajos.Visible = false;
        //actualizarDatosReparacion();
    }

    protected void gvVehiculos_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["OrdenGvVehiculos"] = e.SortExpression;
        CargarGrillaVehiculos();
    }

    protected void gvVehiculos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idVehiculo = (int)gvVehiculos.SelectedDataKey.Value;
        if (ViewState["idVehiculo"] == null) ViewState["idVehiculo"] = idVehiculo;
        
        txtDominio.Text = gvVehiculos.SelectedRow.Cells[1].Text;
        txtMarca.Text = gvVehiculos.SelectedRow.Cells[2].Text;
        txtCliente.Text = gvVehiculos.SelectedRow.Cells[4].Text;

        //Vehiculo v = GestorVehiculos.ObtenerPorId(idVehiculo);
        //txtDominio.Text = v.dominio;
        //txtMarca.Text = v.marca.nombreMarca;
        //txtCliente.Text = v.cliente.nombreCompleto;
        actualizarDatosReparacion();
        btnAgregarTrabajos.Enabled = true;
        btnGuardar.Enabled = true;
        alertaExito.Visible = false;
        alertaError.Visible = false;
    }

    private void actualizarDatosReparacion()
    {
        List<DetalleReparacion> listaDetalles;
        if (ViewState["detallesReparacion"] != null)
        {
            listaDetalles = (List<DetalleReparacion>)ViewState["detallesReparacion"];
            if (listaDetalles.Count == 0)
            {

                txtCantidadDetalles.Text = "0";
                txtTotalReparacion.Text = "$ 0.0";
                //txtSubTotalDetalles.Text = "$ 0.0";
                //txtTotalFactura.Text = txtMO.Text;
                txtFechaFin.Text = "";
                decimal totalReparacion = 0;
                //decimal totalfactura = decimal.Parse(txtMO.Text.Substring(2));
                //txtTotalFactura.Text = "$ " + totalfactura.ToString();
                ViewState["totalReparacion"] = totalReparacion;
            }
            else
            {
                txtCantidadDetalles.Text = listaDetalles.Count.ToString();
                decimal totalReparacion = 0 ;
                DateTime fechaFinEstimada = DateTime.Now;
                int minutosReparacion = 0;
                int diasReparacion = 0;
                int hsDelDia = 0;
                //decimal subtotaldetalles = 0;
                foreach (var item in listaDetalles)
                {
                    totalReparacion += item.trabajo.precioMO;
                    minutosReparacion += item.trabajo.duracion;
                }
                txtTotalReparacion.Text = "$ " + totalReparacion.ToString();
                if (minutosReparacion > 60)
                {
                    decimal hsReparacion = minutosReparacion / 60;
                    int hsRestantes = 21 - DateTime.Now.Hour;
                    if(hsReparacion <= hsRestantes)
                    {
                        string numString = Convert.ToString(hsReparacion / 6);
                        diasReparacion = int.Parse(numString.Split(',')[0]);
                        float partedecimal = float.Parse("0," + numString.Split(',')[1]);
                        hsDelDia = (int)Math.Round(partedecimal * 6);

                    }
                    else
                    {
                        string numString = Convert.ToString(hsReparacion / 6);
                        if(hsReparacion % 6 == 0) {
                            diasReparacion = (int) (hsReparacion / 6);
                            hsDelDia = 0;
                        }
                        else
                        {                            
                            diasReparacion = int.Parse(numString.Split(',')[0]);
                            float partedecimal = float.Parse("0," + numString.Split(',')[1]);
                            hsDelDia = (int)Math.Round(partedecimal * 6);
                        }
                        fechaFinEstimada = DateTime.Today;
                        fechaFinEstimada = fechaFinEstimada.AddDays(1);
                        fechaFinEstimada = fechaFinEstimada.AddHours(9);
                        
                    }
                    
                }
                else {
                    hsDelDia = 1;
                }

                fechaFinEstimada = fechaFinEstimada.AddDays(diasReparacion);
                fechaFinEstimada = fechaFinEstimada.AddHours(hsDelDia);
                txtFechaFin.Text = fechaFinEstimada.ToString("dd/MM/yyyy H ")+ "hs";
                //decimal totalfactura = decimal.Parse(txtMO.Text.Substring(2)) + subtotaldetalles;
                //txtTotalFactura.Text = "$ " + totalfactura.ToString();
                ViewState["fechaFin"] = fechaFinEstimada;
                ViewState["totalReparacion"] = totalReparacion;
            }
        }
        else
        {
            txtCantidadDetalles.Text = "0";
            txtTotalReparacion.Text = "$ 0.0";
            //txtSubTotalDetalles.Text = "$ 0.0";
            //txtTotalFactura.Text = txtMO.Text;
            decimal totalReparacion = 0;
            //decimal totalfactura = decimal.Parse(txtMO.Text.Substring(2));
            //txtTotalFactura.Text = "$ " + totalfactura.ToString();
            ViewState["totalReparacion"] = totalReparacion;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Reparacion r = new Reparacion();
        Vehiculo v = new Vehiculo();
        EstadoReparacion er = new EstadoReparacion();
        er.idEstado = 1;
        //f.numeroFactura = GestorFacturas.ObtenerNumeroMaximo() + 1;
        //f.fechaFactura = DateTime.Now;

        int idVehiculo = (int)ViewState["idVehiculo"];

        //if (ViewState["reparacion"] != null) r = (Reparacion)ViewState["reparacion"];
        v.idVehiculo = idVehiculo;
        r.vehiculo = v;
        r.estadoReparacion = er;
        r.fechaFin = (DateTime) ViewState["fechaFin"];
        r.totalMO = (decimal)ViewState["totalReparacion"];
        
        List<DetalleReparacion> listaDetalles;
        if (ViewState["detallesReparacion"] == null) ViewState["detallesReparacion"] = new List<DetalleFactura>();
        listaDetalles = (List<DetalleReparacion>)ViewState["detallesReparacion"];
        GestorReparaciones.InsertarReparacion(r, listaDetalles);
        alertaExito.Visible = true;
        Inicio();

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void gvDetallesReparacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<DetalleReparacion> listaDetalles = (List<DetalleReparacion>)ViewState["detallesReparacion"];
        int numero = gvDetallesReparacion.SelectedIndex;
        listaDetalles.RemoveAt(numero);
        actualizarDatosReparacion();
        CargarGrillaTrabajos();
    }

    protected void gvDetallesReparacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDetallesReparacion.PageIndex = e.NewPageIndex;
        CargarGrillaTrabajos();
    }

    protected void gvVehiculos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVehiculos.PageIndex = e.NewPageIndex;
        CargarGrillaVehiculos();
    }

    protected void btnAgregarTrabajos_Click(object sender, EventArgs e)
    {
        if (ddlTrabajos.SelectedIndex != 0)
         {
            DetalleReparacion dr = new DetalleReparacion();
            Trabajo t = new Trabajo();
            int idTrabajo = int.Parse(ddlTrabajos.SelectedValue.ToString());


            if (ViewState["detallesReparacion"] == null) ViewState["detallesReparacion"] = new List<DetalleReparacion>();
            List<DetalleReparacion> listaDetalles = (List<DetalleReparacion>)ViewState["detallesReparacion"];

            t = GestorTrabajos.ObtenerPorId(idTrabajo);
            dr.trabajo = t;
            listaDetalles.Add(dr);

            actualizarDatosReparacion();
            CargarGrillaTrabajos();
            ResetDDL();
        }
    }

    private void ResetDDL()
    {
        ddlTrabajos.SelectedIndex = 0;
    }
}
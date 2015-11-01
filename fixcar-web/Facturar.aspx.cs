using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fixcar_negocio;
using fixcar_entidades;
using System.Data;

public partial class Facturar : System.Web.UI.Page
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
        CargarDDLS();
        CargarGrillas();
        //btnEliminar.Enabled = false;
        //ViewState["idCliente"] = null;
        //txtIdCliente.Text = string.Empty;
    }
    private void CargarDDLS()
    {
        CargarDDLRepuestos();
    }

    private void ResetP2()
    {
        ddlRepuestos.SelectedIndex = 0;
        txtCantidadRepuestos.Text = "";
    }

    private void CargarDDLRepuestos()
    {
        List<Repuesto> lista = GestorRepuestos.ObtenerTodos();
        ddlRepuestos.DataSource = lista;
        ddlRepuestos.DataTextField = "nombreRepuesto";
        ddlRepuestos.DataValueField = "idRepuesto";
        ddlRepuestos.DataBind();
        ddlRepuestos.Items.Insert(0, new ListItem("Seleccionar", "0"));
        ddlRepuestos.SelectedIndex = 0;
    }

    private void CargarGrillas()
    {
        CargarGrillaReparaciones();
        CargarGrillaRepuestos();
    }

    private void CargarGrillaReparaciones()
    {
        List<Reparacion> listaReparaciones = GestorReparaciones.ObtenerTodas();
        gvReparaciones.DataSource = listaReparaciones;
        gvReparaciones.DataBind();
    }

    private void CargarGrillaRepuestos()
    {
        if (ViewState["detallesFactura"] == null) ViewState["detallesFactura"] = new List<DetalleFactura>();
        List<DetalleFactura> listaDetalles = (List<DetalleFactura>)ViewState["detallesFactura"];
        gvDetallesFactura.DataSource = listaDetalles;
        gvDetallesFactura.DataBind();

        actualizarDatosFactura();
    }

    private void actualizarDatosFactura()
    {
        List<DetalleFactura> listaDetalles;
        if (ViewState["detallesFactura"] != null)
        {
            listaDetalles = (List<DetalleFactura>)ViewState["detallesFactura"];
            if (listaDetalles.Count == 0)
            {
                txtCantidadDetalles.Text = "0";
                txtSubTotalDetalles.Text = "$ 0.0";
                txtTotalFactura.Text = txtMO.Text;
            }
            else
            {
                txtCantidadDetalles.Text = listaDetalles.Count.ToString();
                decimal subtotaldetalles = 0;
                foreach (var item in listaDetalles)
                {
                    subtotaldetalles += item.subtotal;
                }
                txtSubTotalDetalles.Text = "$ " + subtotaldetalles.ToString();
                decimal totalfactura = decimal.Parse(txtMO.Text.Substring(2)) + subtotaldetalles;
                txtTotalFactura.Text = "$ " + totalfactura.ToString();
            }
        }

    }

    protected void gvReparaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

        int idReparacion = (int)gvReparaciones.SelectedDataKey.Value;
        if (ViewState["idReparacion"] == null) ViewState["idReparacion"] = idReparacion;
        //if (ViewState["reparacion"] == null) ViewState["reparacion"] = new Reparacion();

        Reparacion r = GestorReparaciones.ObtenerPorId(idReparacion);
        txtDominio.Text = r.vehiculo.dominio;
        txtCliente.Text = r.vehiculo.cliente.nombreCompleto;
        txtMO.Text = "$ " + r.totalMO.ToString();
        actualizarDatosFactura();
        //ViewState["reparacion"] = r;
    }

    protected void btnAgregarRepuestos_Click(object sender, EventArgs e)
    {
        if(ddlRepuestos.SelectedIndex != 0 && !string.IsNullOrWhiteSpace(txtCantidadRepuestos.Text))
            {        
            DetalleFactura df = new DetalleFactura();
            Repuesto r = new Repuesto();
            int idRepuesto = int.Parse(ddlRepuestos.SelectedValue.ToString());
            int cantidad = int.Parse(txtCantidadRepuestos.Text.ToString());
            Boolean found = false;

            if (ViewState["detallesFactura"] == null) ViewState["detallesFactura"] = new List<DetalleFactura>();
            List<DetalleFactura> listaDetalles = (List<DetalleFactura>)ViewState["detallesFactura"];

            foreach (var item in listaDetalles)
            {
                if (item.repuesto.idRepuesto == idRepuesto)
                {
                    found = true;

                    if (item.repuesto.stock >= item.cantidad + cantidad)
                    {
                        item.cantidad += cantidad;
                        item.subtotal = item.cantidad * item.repuesto.precio;
                        break;
                    }
                }
                        
            }

            if (!found)
            {
                r = GestorRepuestos.ObtenerPorId(idRepuesto);
                if (r.stock >= cantidad)
                {
                    df.cantidad = cantidad;
                    df.repuesto = r;
                    df.subtotal = cantidad * r.precio;
                    listaDetalles.Add(df);
                    
                }               
                
            }
            else
            {
                //STOCK INSUFICIENTE
            }
            actualizarDatosFactura();
            CargarGrillaRepuestos();
            ResetP2();
        }

    }

    protected void gvDetallesFactura_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<DetalleFactura> listaDetalles = (List<DetalleFactura>)ViewState["detallesFactura"];
        int numero = gvDetallesFactura.SelectedIndex;
        listaDetalles.RemoveAt(numero);
        CargarGrillaRepuestos();

    }
}
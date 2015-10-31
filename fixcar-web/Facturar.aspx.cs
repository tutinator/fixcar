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

    }

    protected void gvReparaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ViewState["reparacion"] == null) ViewState["reparacion"] = new Reparacion();

        int idReparacion = (int)gvReparaciones.SelectedDataKey.Value;
        Reparacion r = GestorReparaciones.ObtenerPorId(idReparacion);

        txtDominio.Text = r.vehiculo.dominio;
        txtCliente.Text = r.vehiculo.cliente.nombreCompleto;
        txtMO.Text = r.totalMO.ToString();
        
        //ViewState["reparacion"] = r;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using fixcar_entidades;
using fixcar_negocio;

public partial class InformeReparaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Inicio();
            ViewState["OrdenGvReparaciones"] = "FechaFin";
        }
    }


    private void Inicio()
    {
        cargarDDLS();
        cargarGrilla();
        //btnEliminar.Enabled = false;
        //ViewState["idCliente"] = null;
        //txtIdCliente.Text = string.Empty;
    }
    private void cargarGrilla()
    {
        string orden = "FechaFin DESC";
        if (ViewState["OrdenGvReparaciones"] != null)
        {
            orden = ViewState["OrdenGvReparaciones"].ToString();
        }

        int idVehiculo = int.Parse(ddlVehiculos.SelectedValue);
        int idEstado = int.Parse(ddlEstados.SelectedValue);

        decimal totalDesde = -1;
        if (!string.IsNullOrWhiteSpace(txtTotalDesde.Text))
        {
            totalDesde = decimal.Parse(txtTotalDesde.Text);
        }

        decimal totalHasta = -1;
        if (!string.IsNullOrWhiteSpace(txtTotalHasta.Text))
        {
            totalHasta = decimal.Parse(txtTotalHasta.Text);
        }

        List<Reparacion> listaReparaciones = GestorReparaciones.Obtener(idVehiculo, idEstado, totalDesde, totalHasta, orden);
        gvReparaciones.DataSource = listaReparaciones;
        gvReparaciones.DataBind();



        DataTable dt = gvReparaciones.DataSource as DataTable;
        ViewState["dt"] = dt;
    }

    private void cargarDDLS()
    {
        cargarDDLVehiculos();
        cargarDDLEstados();
    }

    private void cargarDDLVehiculos()
    {
        List<Vehiculo> lista = GestorVehiculos.ObtenerTodos();
        ddlVehiculos.DataSource = lista;
        //ddlVehiculos.DataTextField = "dominio";
        //ddlVehiculos.DataValueField = "idVehiculo";
        ddlVehiculos.DataBind();
        ddlVehiculos.Items.Insert(0, new ListItem("Todos", "0"));
        ddlVehiculos.SelectedIndex = 0;

    }

    private void cargarDDLEstados()
    {
        List<EstadoReparacion> lista = GestorEstadosReparacion.ObtenerTodos();
        ddlEstados.DataSource = lista;
        //ddlEstados.DataTextField = "nombreEstado";
        //ddlEstados.DataValueField = "idEstado";
        ddlEstados.DataBind();
        ddlEstados.Items.Insert(0, new ListItem("Todos", "0"));
        ddlEstados.SelectedIndex = 0;

    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        cargarGrilla();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlVehiculos.SelectedIndex = 0;
        ddlEstados.SelectedIndex = 0;
        txtTotalDesde.Text = "";
        txtTotalHasta.Text = "";
        cargarGrilla();
    }



    protected void gvReparaciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReparaciones.PageIndex = e.NewPageIndex;
        cargarGrilla();
    }


    protected void ddlVehiculos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvReparaciones_Sorting(object sender, GridViewSortEventArgs e)
    {
        //if (e.SortExpression == "vehiculo.dominio") { ViewState["OrdenGvReparaciones"] = "dominio"; }
        //else if (e.SortExpression == "vehiculo.cliente.nombreCompleto") { ViewState["OrdenGvReparaciones"] = "apellido"; }
        //else if (e.SortExpression == "estadoReparacion.nombreEstado") { ViewState["OrdenGvReparaciones"] = "nombreEstado"; }
        //else if (e.SortExpression == "total") { ViewState["OrdenGvReparaciones"] = "totalMO"; }
        ViewState["OrdenGvReparaciones"] = e.SortExpression; 
        cargarGrilla();
    }
}
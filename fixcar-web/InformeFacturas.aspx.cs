using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fixcar_negocio;
using fixcar_entidades;
using System.Data;


public partial class InformeFacturas : System.Web.UI.Page
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
        cargarDDLS();
        cargarGrilla();
        //btnEliminar.Enabled = false;
        //ViewState["idCliente"] = null;
        //txtIdCliente.Text = string.Empty;
    }
    private void cargarGrilla()
    {
       DateTime? fechaDesde = null;
       if (!string.IsNullOrWhiteSpace(txtFechaDesde.Text))
       {
            fechaDesde = DateTime.Parse(txtFechaDesde.Text);
       }

        DateTime? fechaHasta = null;
        if (!string.IsNullOrWhiteSpace(txtFechaHasta.Text))
        {
            fechaHasta = DateTime.Parse(txtFechaHasta.Text);
        }

        int idCliente = int.Parse(ddlCliente.SelectedValue);

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

        List<Factura> listaFacturas = GestorFacturas.Obtener(fechaDesde, fechaHasta, idCliente, totalDesde, totalHasta);
        gvFacturas.DataSource = listaFacturas;
        gvFacturas.DataBind();

        

        DataTable dt = gvFacturas.DataSource as DataTable;
        ViewState["dt"] = dt;
    }

    private void cargarDDLS()
    {
        cargarDDLClientes();

    }

    private void cargarDDLClientes()
    {
        List<Cliente> lista = GestorClientes.ObtenerTodos();
        ddlCliente.DataSource = lista;
        ddlCliente.DataTextField = "nombreCompleto";
        ddlCliente.DataValueField = "idCliente";
        ddlCliente.DataBind();
        ddlCliente.Items.Insert(0, new ListItem("Todos", "0"));
        ddlCliente.SelectedIndex = 0;

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtFechaDesde.Text = "";
        txtFechaHasta.Text = "";
        ddlCliente.SelectedIndex = 0;
        txtTotalDesde.Text = "";
        txtTotalHasta.Text = "";
        cargarGrilla();
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        cargarGrilla();
    }



    protected void gvFacturas_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            dt.DefaultView.Sort = e.SortExpression + " " + cambiarSortDirection();
            gvFacturas.DataSource = dt;
            gvFacturas.DataBind();
        }

    }

    private string sortDirection = "ASC";
    protected string cambiarSortDirection()
    {
        if (sortDirection == "ASC")
        {
            sortDirection = "DESC";
            return sortDirection;
        }
        else
        {
            sortDirection = "ASC";
            return sortDirection;
        }
    }


    protected void gvFacturas_PageIndexChanged(object sender, EventArgs e)
    {

    }

    

    protected void gvFacturas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFacturas.PageIndex = e.NewPageIndex;
        cargarGrilla();
    }
}


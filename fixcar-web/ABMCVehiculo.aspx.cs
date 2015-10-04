using System;
using fixcar_negocio;
using fixcar_entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ABMCVehiculo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarGrilla();
            CargarDDLs();
        }
    }


    private void CargarGrilla()
    {
        gvVehiculos.DataSource = GestorVehiculos.ObtenerTodos();
        gvVehiculos.DataBind();
    }

    private void CargarDDLs()
    {
        List<Marca> lista = GestorMarcas.ObtenerTodas();
        ddlMarca.DataSource = lista;
        ddlMarca.DataTextField = "nombreMarca";
        ddlMarca.DataValueField = "idMarca";
        ddlMarca.DataBind();
        
    }
    protected void gvVehiculos_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
}
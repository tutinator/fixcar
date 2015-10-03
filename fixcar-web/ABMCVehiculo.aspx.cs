using System;
using fixcar_negocio;
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
        }
    }


    private void CargarGrilla()
    {
        gvVehiculos.DataSource = GestorVehiculos.ObtenerTodos();
        gvVehiculos.DataBind();

    }
    
}
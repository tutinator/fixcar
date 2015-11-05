using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        
        if((string)Session["Usuario"] == "admin")
        {
            pInfoReparaciones.Visible = true;
            pInfoFacturas.Visible = true;
            pGestionVehiculos.Visible = true;
            pGestionClientes.Visible = true;
            pFacturar.Visible = true;
            pRegReparacion.Visible = true;
        }
        if ((string)Session["Usuario"] == "mecanico")
        {
            pGestionVehiculos.Visible = true;
            pGestionClientes.Visible = true;
            pRegReparacion.Visible = true;
            pInfoReparaciones.Visible = true;
        }

        if((string)Session["Usuario"] == "vendedor")
        {
            pGestionClientes.Visible = true;
            pInfoFacturas.Visible = true;
            pFacturar.Visible = true;
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fixcar_negocio;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        if (GestorSesiones.estaAutenticado(login.UserName, login.Password))
        {
            e.Authenticated = true;  // genera cookie de seguridad con datos del usuario 
            Session["Usuario"] = login.UserName;
            Response.Redirect("Default.aspx");
            
        }
        else
        {
            e.Authenticated = false;
            Session["Usuario"] = "";
        }
    }
}
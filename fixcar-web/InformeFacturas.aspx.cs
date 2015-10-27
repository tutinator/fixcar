﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fixcar_negocio;
using fixcar_entidades;

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

        gvFacturas.DataSource = GestorFacturas.Obtener(fechaDesde, fechaHasta, idCliente, totalDesde, totalHasta);
        gvFacturas.DataBind();
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
        ddlCliente.Items.Insert(0, new ListItem("Seleccione el propietario", "0"));
        ddlCliente.SelectedIndex = 0;

    }
}
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
            Inicio();
        }
    }

    private void Inicio()
    {
        CargarGrilla();
        CargarDDLs();
        btnEliminar.Enabled = false;
        ViewState["idVehiculo"] = null;
        txtIdVehiculo.Text = string.Empty;

    }
    private void CargarGrilla()
    {
        gvVehiculos.DataSource = GestorVehiculos.ObtenerTodos();
        gvVehiculos.DataBind();
    }

    private void CargarDDLs()
    {
        CargarDDLMarcas();
        CargarDDLClientes();        
    }

    private void CargarDDLMarcas()
    {
        List<Marca> lista = GestorMarcas.ObtenerTodas();
        ddlMarca.DataSource = lista;
        ddlMarca.DataTextField = "nombreMarca";
        ddlMarca.DataValueField = "idMarca";
        ddlMarca.DataBind();
    }

    private void CargarDDLClientes()
    {
        List<Cliente> lista = GestorClientes.ObtenerTodos();
        ddlCliente.DataSource = lista;
        ddlCliente.DataTextField = "nombreCompleto";
        ddlCliente.DataValueField = "idCliente";
        ddlCliente.DataBind();
    }
    protected void gvVehiculos_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idVehiculo = (int)gvVehiculos.SelectedDataKey.Value;
        Vehiculo v = GestorVehiculos.ObtenerPorId(idVehiculo);

        ViewState["idVehiculo"] = v.idVehiculo.ToString();
        txtIdVehiculo.Text = v.idVehiculo.ToString();
        txtDominio.Text = v.dominio.ToString();
        ddlCliente.SelectedValue = v.cliente.idCliente.ToString();
        ddlMarca.SelectedValue = v.marca.idMarca.ToString();
        txtKm.Text = v.km.ToString();
        txtAno.Text = v.ano.ToString();

        if (v.pinturaDanada) cbPintura.Checked = true;
        else cbPintura.Checked = false;

        btnEliminar.Enabled = true;
        txtDominio.Enabled = false;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string dominio = txtDominio.Text;
        int idCliente = int.Parse(ddlCliente.SelectedValue);
        int idMarca = int.Parse(ddlMarca.SelectedValue);
        int km = int.Parse(txtKm.Text);
        int ano = int.Parse(txtAno.Text);
        bool pinturaDanada = false;
        if (cbPintura.Checked) pinturaDanada = true;

        Vehiculo v = new Vehiculo();
        v.dominio = dominio;
        v.ano = ano;
        v.km = km;
        v.pinturaDanada = pinturaDanada;

        Cliente c = new Cliente();
        c.idCliente = idCliente;
        v.cliente = c;

        Marca m = new Marca();
        m.idMarca = idMarca;
        v.marca = m;

        if (ViewState["idVehiculo"] == null)
        {
            //NUEVO VEHICULO     
            GestorVehiculos.InsertarVehiculo(v);
        }
        else
        {
            //ACTUALIZAR VEHICULO
            v.idVehiculo = int.Parse(ViewState["idVehiculo"].ToString());
            GestorVehiculos.ActualizarVehiculo(v);
        }
        Inicio();
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Nuevo();
    }

    protected void Nuevo()
    {
        ddlCliente.ClearSelection();
        ddlCliente.SelectedIndex = 0;
        ddlMarca.ClearSelection();
        ddlMarca.SelectedIndex = 0;

        ViewState["idVehiculo"] = null;
        txtIdVehiculo.Text = string.Empty;
        txtAno.Text = string.Empty;
        txtDominio.Text = string.Empty;        
        txtKm.Text = string.Empty;

        txtDominio.Enabled = true;
        btnEliminar.Enabled = false;

    }
}
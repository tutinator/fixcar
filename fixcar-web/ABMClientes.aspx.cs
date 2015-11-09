using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using fixcar_negocio;
using fixcar_entidades;

public partial class ABMClientes : System.Web.UI.Page
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
        cargarGrilla();
        cargarDDLS();
        btnEliminar.Enabled = false;
        ViewState["idCliente"] = null;
        txtIdCliente.Text = string.Empty;
    }
    private void cargarGrilla()
    {
        gvClientes.DataSource = GestorClientes.ObtenerTodos();
        gvClientes.DataBind();
    }

    private void cargarDDLS()
    {
        cargarDDLTiposDocumento();
        
    }

    private void cargarDDLTiposDocumento()
    {
        List<TipoDocumento> lista = GestorTipoDocumento.obtenerTodos();
        ddlTipoDocumento.DataSource = lista;
        ddlTipoDocumento.DataTextField = "nombreTipoDocumento";
        ddlTipoDocumento.DataValueField = "idTipoDocumento";
        ddlTipoDocumento.DataBind();
        ddlTipoDocumento.Items.Insert(0, new ListItem("Seleccione Tipo de Documento", "0"));
        ddlTipoDocumento.SelectedIndex = 0;
        
    }

  
    protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idCliente = (int)gvClientes.SelectedDataKey.Value;
        Cliente c = GestorClientes.ObtenerPorId(idCliente);

        ViewState["idCliente"] = c.idCliente.ToString();
        txtIdCliente.Text = c.idCliente.ToString();
        txtNombre.Text = c.nombre.ToString();
        txtApellido.Text = c.apellido.ToString();
        ddlTipoDocumento.SelectedValue = c.tipoDocumento.idTipoDocumento.ToString();
        txtNumeroDocumento.Text = c.numeroDocumento.ToString();
        txtFechaNacimiento.Text = c.fechaNacimiento.ToString("dd/MM/yyyy");
        if(c.genero == null)
        {
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
        }else if (c.genero == true) rbFemenino.Checked = true;
        else rbMasculino.Checked = true;

        btnEliminar.Enabled = true;
        alertaExito.Visible = false;
        alertaError.Visible = false;
        alertaErrorEliminacion.Visible = false;
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Nuevo();
        alertaExito.Visible = false;
        alertaError.Visible = false;
        alertaErrorEliminacion.Visible = false;
    }

    protected void Nuevo()
    {
        ddlTipoDocumento.ClearSelection();
        ddlTipoDocumento.SelectedIndex = 0;
        rbFemenino.Checked = false;
        rbMasculino.Checked = false;

        ViewState["idCliente"] = null;
        txtApellido.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtNumeroDocumento.Text = string.Empty;
        txtFechaNacimiento.Text = string.Empty;

        //txtDominio.Enabled = true;
        btnEliminar.Enabled = false;

    }

    protected void btnGuardar_Click1(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        int idTipoDocumento = int.Parse(ddlTipoDocumento.SelectedValue);
        int numeroDoc = int.Parse(txtNumeroDocumento.Text);
        DateTime fechaNacimento = DateTime.Parse(txtFechaNacimiento.Text);
        bool? genero = null;
        if (rbFemenino.Checked) genero = true;
        if (rbMasculino.Checked) genero = false;
        Cliente c = new Cliente();
        c.nombre = nombre;
        c.apellido = apellido;
        TipoDocumento t = new TipoDocumento();
        t.idTipoDocumento = idTipoDocumento;
        c.tipoDocumento = t;
        c.numeroDocumento = numeroDoc;
        c.fechaNacimiento = fechaNacimento;
        c.genero = genero;

        if (ViewState["idCliente"] == null)
        {
            //NUEVO CLIENTE
            try {
                GestorClientes.insertarCliente(c);
                alertaExito.Visible = true;
            }
            catch (Exception ex) {
                alertaError.Visible = true;
            }
        }
        else
        {
            //ACTUALIZAR CLIENTE
            try {
                c.idCliente = int.Parse(ViewState["idCliente"].ToString());
                GestorClientes.actualizarCliente(c);
                alertaExito.Visible = true;
            }
            catch(ApplicationException ex)
            {
                alertaError.Visible = true;
            }
            
        }
        Inicio();
        //Response.Redirect(Request.RawUrl);
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
       
        if (!(ViewState["idCliente"] == null))
        {
            Cliente c = new Cliente();
            c.idCliente= int.Parse(ViewState["idCliente"].ToString());
            try
            {

                GestorClientes.eliminarCliente(c);
                alertaExito.Visible = true;
            }
            catch (ApplicationException ex)
            {
                alertaErrorEliminacion.Visible = true;
            }
                      
                
        }
    }

    protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvClientes.PageIndex = e.NewPageIndex;
        cargarGrilla();
        alertaExito.Visible = false;
        alertaError.Visible = false;
        alertaErrorEliminacion.Visible = false;
    }
}
<%@ Page Title="Gestión de Clientes" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ABMClientes.aspx.cs" Inherits="ABMClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="bootstrap.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <script type="text/JavaScript" runat ="server">
        //alert('');

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="page-header">
            <h3>Gestión de Clientes</h3>
        </div>

        <div class="row">
            <div class="col-md-8">
                <asp:GridView ID="gvClientes" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" DataKeyNames="idCliente">
                    <Columns>
                        <asp:BoundField DataField="idCliente" Visible="false" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="tipoDocumento.nombreTipoDocumento" HeaderText="Tipo de Documento" />
                        <asp:BoundField DataField="numeroDocumento" HeaderText="Documento" />
                        <asp:BoundField DataField="fechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" NullDisplayText="-" />
                        <asp:BoundField DataField="generoString" HeaderText="Genero" />
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            
            </div>

            <div class="col-md-4">

                <asp:TextBox ID="txtIdCliente" runat="server" Visible="false"></asp:TextBox>

                <div class="form-group">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" Text="Ingrese el nombre del cliente" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reNombre" runat="server" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z]{1,30}$" Display="Dynamic" Text="" ErrorMessage="Nombre inválido. Ingrese solo letras." CssClass="text-danger"></asp:RegularExpressionValidator>

                </div>
                <div class="form-group">
                    <label for="txtApellido">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" Text="Ingrese el apellido del cliente" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reApellido" runat="server" ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z]{1,30}$" Display="Dynamic" Text="" ErrorMessage="Apellido inválido. Ingrese solo letras." CssClass="text-danger"></asp:RegularExpressionValidator>

                </div>
                <div class="form-group">
                    <label for="ddlTipoDocumento">Tipo de Documento</label>
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipoDocumento" runat="server" ControlToValidate="ddlTipoDocumento" InitialValue="0" Text="Seleccione un tipo de documento" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtNumeroDocumento">Documento</label>
                    <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNumeroDocumento" runat="server" ControlToValidate="txtNumeroDocumento" Text="Ingrese el número de documento del cliente" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="reNumeroDocumento" runat="server" ControlToValidate="txtNumeroDocumento" ValidationExpression="^[0-9]{12}$" Display="Dynamic" Text="" ErrorMessage="Documento inválido. Ingrese solo números." CssClass="text-danger"></asp:RegularExpressionValidator>--%>
                </div>
                <div class="form-group">
                    <label for="txtFechaNacimiento">Fecha de Nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="genero">Genero: </label>
                    <%--<asp:Label ID="lblGenero" runat="server" Text="Genero" />--%>
                    <asp:RadioButton ID="rbMasculino" runat="server" Checked="false" CssClass="radio-inline" GroupName="genero" Text="Masculino" />
                    <asp:RadioButton ID="rbFemenino" runat="server" Checked="false" CssClass="radio-inline" GroupName="genero" Text="Femenino" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" CausesValidation="false" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnGuardar_Click1" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />

                </div>
                                
            </div>
        </div>
     </div>
    <script>
        $(function () {
            $("[id$=txtFechaNacimiento]").datepicker({
                defaultDate: "-1m",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 3,
                maxDate: "+1D",
                dateFormat: 'dd/mm/yy',
                onClose: function (selectedDate) {
                    $("[id$=txtFechaNacimiento]").datepicker("option", "minDate", selectedDate);
                }
            });

        });
    </script>
       
</asp:Content>


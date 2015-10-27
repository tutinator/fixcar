<%@ Page Title="Gestión de Vehículos" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ABMCVehiculos.aspx.cs" Inherits="ABMCVehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title></title>
    <script src="bootstrap.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h3>Gestión de Vehículos</h3>
        </div>

        <div class="row">
            <div class="col-md-8">
                <asp:GridView ID="gvVehiculos" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvVehiculos_SelectedIndexChanged" DataKeyNames="idVehiculo">
                    <Columns>
                        <asp:BoundField DataField="idVehiculo" HeaderText="ID" Visible="false" />
                        <asp:BoundField DataField="dominio" HeaderText="Dominio" />
                        <asp:BoundField DataField="marca.nombreMarca" HeaderText="Marca" />
                        <asp:BoundField DataField="cliente.nombreCompleto" HeaderText="Propietario" />
                        <asp:BoundField DataField="ano" HeaderText="Modelo" />
                        <asp:BoundField DataField="km" HeaderText="Kilometraje" />
                        <asp:CheckBoxField DataField="pinturaDanada" HeaderText="Pintura Dañada" />
                        <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>

            </div>

            <div class="col-md-4">

                <asp:TextBox ID="txtIdVehiculo" runat="server" Visible="false"></asp:TextBox>

                <div class="form-group">
                    <label for="txtDominio">Dominio</label>
                    <asp:TextBox ID="txtDominio" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvDominio" runat="server" ControlToValidate="txtDominio" Text="Ingrese el Dominio del vehículo" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="reDominio" runat="server" ControlToValidate="txtDominio" ValidationExpression="^[a-zA-Z]{3}[0-9]{3}$" Display="Dynamic" Text="" ErrorMessage="Dominio inválido. Formato sugerido: ABC123" CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>

                <div class="form-group">
                    <label for="ddlCliente">Propietario</label>
                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ControlToValidate="ddlCliente" InitialValue="0" Text="Seleccione un propietario" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="ddlMarca">Marca</label>
                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="ddlMarca" InitialValue="0" Display="Dynamic" CssClass="text-danger" ErrorMessage="Seleccione una marca"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtKm">Kilometraje</label>
                    <asp:TextBox ID="txtKm" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="reKm" runat="server" ControlToValidate="txtKm" ValidationExpression="^\d{10}" Display="Dynamic" Text="" ErrorMessage="Kilometraje inválido. Ingrese sólo números." CssClass="text-danger"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <label for="txtAno">Modelo</label>
                    <asp:TextBox ID="txtAno" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="reAno" runat="server" ControlToValidate="txtAno" ValidationExpression="^\d{4}$" Display="Dynamic" Text="" ErrorMessage="Año inválido. Ingrese sólo números." CssClass="text-danger"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvAno" runat="server" ControlToValidate="txtAno" Text="Ingrese el modelo del vehículo" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="checkbox form-group">
                    <asp:CheckBox ID="cbPintura" runat="server" Text="Pintura Dañada" />
                </div>
                <div class="btn-group" role="group">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" CausesValidation="false" />
                    <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar" runat="server" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />

                </div>

            </div>
        </div>
        
    </div>

</asp:Content>


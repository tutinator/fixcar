<%@ Page Title="Gestión de Vehículos" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="ABMCVehiculos.aspx.cs" Inherits="ABMCVehiculos" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h3>Gestión de Vehículos <small>Alta, baja, modificación o consulta de un vehículo y sus datos.</small> </h3>
        </div>
        <div id="alertaExito" runat="server" class="alert alert-success" role="alert" visible="false">
                                    <span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span> Operación realizada con éxito</div>
        
        <div id="alertaError" runat="server" class="alert alert-danger" role="alert" visible ="false">
                                    <span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span> Error al insertar vehículo: Dominio ya registrado</div>

        <div id="alertaErrorEliminacion" runat="server" class="alert alert-danger" role="alert" visible ="false">
                                    <span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span> Error al eliminar vehículo: Existen reparaciones/facturaciones pendientes</div>

        <div class="row">
            <div class="col-md-8">
                 <div class="panel panel-primary">
                <div class="panel-heading">
                    Vehículos Registrados
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvVehiculos" runat="server" PageSize="12" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvVehiculos_SelectedIndexChanged" DataKeyNames="idVehiculo" OnPageIndexChanging="gvVehiculos_PageIndexChanging">
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
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-info">
                <div class="panel-heading">
                   <strong>Datos</strong> 
                </div>
                <div class="panel-body">

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
                    <asp:RegularExpressionValidator ID="reKm" runat="server" ControlToValidate="txtKm" ValidationExpression="\d+" Display="Dynamic" Text="" ErrorMessage="Kilometraje inválido. Ingrese sólo números." CssClass="text-danger"></asp:RegularExpressionValidator>
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
        </div>
        
    </div>

</asp:Content>


<%@ Page Title="Nueva Factura" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Facturar.aspx.cs" Inherits="Facturar" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h3>Facturar Reparación y Repuestos</h3>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                1. Elegir Reparación a facturar
            </div>
            <div class="panel-body">
                <div class="row">

                    <div class="col-md-8">
                        <asp:GridView ID="gvReparaciones" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvReparaciones_SelectedIndexChanged" DataKeyNames="idReparacion">
                            <Columns>
                                <asp:BoundField DataField="idReparacion" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="vehiculo.dominio" HeaderText="Dominio" SortExpression="vehiculo.dominio" />
                                <asp:BoundField DataField="vehiculo.cliente.nombreCompleto" HeaderText="Cliente" SortExpression="vehiculo.cliente.nombreCompleto" />
                                <asp:BoundField DataField="estadoReparacion.nombreEstado" HeaderText="Estado" SortExpression="estadoReparacion.nombreEstado" />
                                <asp:BoundField DataField="totalMO" HeaderText="Costo MO" SortExpression="reparacion.totalMO" DataFormatString="{0:C}" />
                                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="col-md-4">

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtDominio" CssClass="control-label">Dominio:</asp:Label>
                            <asp:TextBox ID="txtDominio" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtCliente" CssClass="control-label">Cliente:</asp:Label>
                            <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtMO" CssClass="control-label">Costo MO:</asp:Label>
                            <asp:TextBox ID="txtMO" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                2. Agregar Repuestos a la factura
            </div>
            <div class="panel-body">
                <div class="row">

                    <div class="col-md-8">
                        
                            
                        <div class="row">
                            
                                <asp:Label runat="server" AssociatedControlID="ddlRepuestos" CssClass="control-label col-md-2">Repuesto:</asp:Label>

                                <div class="form-group col-md-3">
                                    <asp:DropDownList ID="ddlRepuestos" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                </div>
                            
                            
                                <asp:Label runat="server" AssociatedControlID="txtCantidadRepuestos" CssClass="control-label col-md-2">Cantidad:</asp:Label>

                                <div class="form-group col-md-3">
                                    <asp:TextBox ID="txtCantidadRepuestos" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            
                            <div class="col-md-2">
                                <div class="btn-group" role="group">
                                    <asp:Button ID="btnAgregarRepuestos" runat="server" Text="Agregar" CssClass="btn btn-default btn-sm" CausesValidation="false" />
                                </div>
                            </div>
                        </div>
                                
                            
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvRepuestos" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True">
                                    <Columns>
                                        <asp:BoundField DataField="idFactura" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="numeroFactura" HeaderText="Numero" SortExpression="numeroFactura" />
                                        <asp:BoundField DataField="fechaFactura" HeaderText="Fecha" SortExpression="fechaFactura" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="reparacion.vehiculo.dominio" HeaderText="Dominio" SortExpression="vehiculo.dominio" />
                                        <asp:BoundField DataField="reparacion.vehiculo.cliente.nombreCompleto" HeaderText="Cliente" SortExpression="vehiculo.cliente.nombreCompleto" />
                                        <asp:BoundField DataField="reparacion.vehiculo.cliente.numeroDocumento" HeaderText="Documento" SortExpression="vehiculo.cliente.numeroDocumento" />
                                        <asp:BoundField DataField="reparacion.totalMO" HeaderText="Costo MO" SortExpression="reparacion.totalMO" DataFormatString="{0:C}" />
                                        <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" DataFormatString="{0:C}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-4">
                        <%-- datos factura --%>
                        <p>Datos Factura</p>

                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                3. Generar Factura
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12 ">
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Facturar" runat="server" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>











    </div>
</asp:Content>

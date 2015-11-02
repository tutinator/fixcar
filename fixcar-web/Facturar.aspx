<%@ Page Title="Nueva Factura" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="Facturar.aspx.cs" Inherits="Facturar" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h3>Facturar Reparación y Repuestos <small>Registrar la facturación de una reparación realizada a un vehículo y de los repuestos utilizados.</small> </h3>
        </div>
        <div id="alertaExito" runat="server" class="alert alert-success" role="alert" visible="false">
                                    <span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span> Factura registrada con éxito</div>
        
        <div id="alertaError" runat="server" class="alert alert-danger" role="alert" visible ="false">
                                    <span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span> Error en la facturación. Cambios cancelados.</div>


        <div class="panel panel-primary">
            <div class="panel-heading">
                1. Elegir Reparación a facturar
            </div>
            <div class="panel-body">
                <div class="row">

                    <div class="col-md-8">
                        <div id="alertaNoReparaciones" runat="server" class="alert alert-warning" role="alert" visible="false">
                                    <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span> No hay reparaciones terminadas para facturar</div>
                        <asp:GridView ID="gvReparaciones" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvReparaciones_SelectedIndexChanged" DataKeyNames="idReparacion" OnPageIndexChanging="gvReparaciones_PageIndexChanging">
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

        <div class="panel panel-primary">
            <div class="panel-heading">
                2. Agregar Repuestos a la factura
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-5">
                                <asp:DropDownList ID="ddlRepuestos" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                                <asp:RegularExpressionValidator ID="reCantRep" ValidationGroup="cantidad" runat="server" ControlToValidate="txtCantidadRepuestos" ValidationExpression="\d+" Display="Dynamic" Text="" ErrorMessage="Cantidad inválida. Ingrese sólo números." CssClass="text-danger"></asp:RegularExpressionValidator>
                            </div>
                            <div class="input-group input-group-sm col-md-3" id="cantidad">
                                <span class="input-group-addon">Cantidad:</span>
                                <asp:TextBox ID="txtCantidadRepuestos" ValidationGroup="cantidad" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <div class="btn-group" role="group">
                                    <asp:Button ID="btnAgregarRepuestos" runat="server" ValidationGroup="cantidad" Text="Agregar" CssClass="btn btn-default btn-sm" OnClick="btnAgregarRepuestos_Click" />
                                </div>
                            </div>
                        </div>
                        <br />
                       <div class="row">
                            <div class="col-md-12">
                                <div id="alertaNoRepuestos" runat="server" class="alert alert-warning" role="alert" visible="false">
                                    <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span> No hay repuestos a facturar</div>
                                <div id="alertaStockInsuficiente" runat="server" class="alert alert-danger" role="alert" visible ="false">
                                    <span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span> Stock insuficiente de ese repuesto</div>
                                <asp:GridView ID="gvDetallesFactura" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvDetallesFactura_SelectedIndexChanged" OnPageIndexChanging="gvDetallesFactura_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="repuesto.idRepuesto" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="repuesto.nombreRepuesto" HeaderText="Repuesto"/>
                                        <asp:BoundField DataField="repuesto.stock" HeaderText="Stock"/>
                                        <asp:BoundField DataField="repuesto.precio" HeaderText="Precio" DataFormatString="{0:C}" />
                                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad"/>                                        
                                        <asp:BoundField DataField="subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
                                        <asp:CommandField SelectText="Quitar" ShowSelectButton="True" />                                      
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtCantidadDetalles" CssClass="control-label">Cantidad Repuestos:</asp:Label>
                            <asp:TextBox ID="txtCantidadDetalles" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtSubTotalDetalles" CssClass="control-label">Subtotal Repuestos:</asp:Label>
                            <asp:TextBox ID="txtSubTotalDetalles" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtTotalFactura" CssClass="control-label">Total Factura:</asp:Label>
                            <asp:TextBox ID="txtTotalFactura" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-success">
            <div class="panel-heading">
                <strong>3. Generar Factura</strong>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12 ">
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Facturar" runat="server" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>











    </div>
</asp:Content>

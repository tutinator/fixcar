<%@ Page Title ="Registrar Reparación" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="RegistrarReparacion.aspx.cs" Inherits="RegistrarReparacion" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="container">
        <div class="page-header">
            <h3> Registrar Reparacion <small>Registrar una nueva reparación realizada a un vehículo y los trabajos realizados.</small> </h3>
        </div>
        <div id="alertaExito" runat="server" class="alert alert-success" role="alert" visible="false">
                                    <span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span> Reparación registrada con éxito
        </div>
        
        <div id="alertaError" runat="server" class="alert alert-danger" role="alert" visible ="false">
            <span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span> Error en la registración. Cambios cancelados.
        </div>


        <div class="panel panel-primary">
            <div class="panel-heading">
                1. Elegir vehículo reparado
            </div>
            <div class="panel-body">
                
                <div class="row">
                    <div class="col-md-8">
                        <asp:GridView ID="gvVehiculos" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="idVehiculo" AllowSorting="True" OnSorting="gvVehiculos_Sorting" OnSelectedIndexChanged="gvVehiculos_SelectedIndexChanged" OnPageIndexChanging="gvVehiculos_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="idVehiculo" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="dominio" HeaderText="Dominio" SortExpression="dominio DESC" />
                                <asp:BoundField DataField="marca.nombreMarca" HeaderText="Marca" SortExpression="nombreMarca" />
                                <asp:CheckBoxField DataField="pinturaDanada" HeaderText="Pintura Dañada" SortExpression =""/>
                                <asp:BoundField DataField="cliente.nombreCompleto" HeaderText="Cliente" SortExpression="apellido" />
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
                            <asp:Label runat="server" AssociatedControlID="txtMarca" CssClass="control-label">Marca:</asp:Label>
                            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtCliente" CssClass="control-label">Cliente dueño:</asp:Label>
                            <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
            
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">
                2. Seleccionar Trabajos realizados en la reparación
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-5">
                                <asp:DropDownList ID="ddlTrabajos" runat="server" CssClass="form-control input-sm"></asp:DropDownList>
                           <%--     <asp:RegularExpressionValidator ID="reCantRep" ValidationGroup="cantidad" runat="server" ControlToValidate="txtCantidadRepuestos" ValidationExpression="\d+" Display="Dynamic" Text="" ErrorMessage="Cantidad inválida. Ingrese sólo números." CssClass="text-danger"></asp:RegularExpressionValidator>--%>
                            </div>
<%--                            <div class="input-group input-group-sm col-md-3" id="cantidad">
                                <span class="input-group-addon">Cantidad:</span>
                                <asp:TextBox ID="txtCantidadRepuestos" ValidationGroup="cantidad" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                            </div>--%>
                            <div class="col-md-2">
                                <div class="btn-group" role="group">
                                    <asp:Button ID="btnAgregarTrabajos" runat="server" ValidationGroup="cantidad" Text="Agregar" CssClass="btn btn-default btn-sm" OnClick="btnAgregarTrabajos_Click" />
                                </div>
                            </div>
                        </div>
                        <br />
                       <div class="row">
                            <div class="col-md-12">
                                 <div id="alertaNoTrabajos" runat="server" class="alert alert-warning" role="alert" visible="false">
                                    <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span> No hay trabajos seleccionados</div>
                                <asp:GridView ID="gvDetallesReparacion" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvDetallesReparacion_PageIndexChanging" OnSelectedIndexChanged="gvDetallesReparacion_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="trabajo.idTrabajo" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="trabajo.nombreTrabajo" HeaderText="Trabajo"/>
                                        <asp:BoundField DataField="trabajo.duracion" HeaderText="Duración (min)"/>
                                        <asp:BoundField DataField="trabajo.precioMO" HeaderText="Precio" DataFormatString="{0:C}" />
                                        <%--<asp:BoundField DataField="cantidad" HeaderText="Cantidad"/>                                        
                                        <asp:BoundField DataField="subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />--%>
                                        <asp:CommandField SelectText="Quitar" ShowSelectButton="True" />                                      
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtCantidadDetalles" CssClass="control-label">Cantidad de trabajos a realizar:</asp:Label>
                            <asp:TextBox ID="txtCantidadDetalles" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
<%--                    <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtSubTotalDetalles" CssClass="control-label">Subtotal Trabajos:</asp:Label>
                            <asp:TextBox ID="txtSubTotalDetalles" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>--%>
                        <div class="form-group">
                            <asp:Label runat ="server" AssociatedControlID="txtFechaFin" CssClass="control-label"> Fecha estimada de finalización:</asp:Label>
                            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="txtTotalReparacion" CssClass="control-label">Total presupuestado para la reparación:</asp:Label>
                            <asp:TextBox ID="txtTotalReparacion" runat="server" CssClass="form-control input-sm" Enabled="false"></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-success">
            <div class="panel-heading">
                <strong>3. Registrar Reparación</strong>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12 ">
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Registrar" runat="server" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" CausesValidation="false" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
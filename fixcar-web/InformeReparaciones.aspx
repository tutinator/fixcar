<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="InformeReparaciones.aspx.cs" Inherits="InformeReparaciones" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
        <div class="page-header">
            <h3>Informe de Reparaciones<small>Reporte de reparaciones terminadas y pendientes por FixCar</small></h3>
        </div>
        <div class="panel panel-info">
            <div id="pheading1" class="panel-heading">
                <strong>Filtros</strong>
            </div>
            <div id="pbody1" class="panel-body">
                <div class="row">

                    <div class="col-md-4">
                        <div class="form-group">


                            <label for="ddlVehiculos" class="col-md-offset-1">Dominio del Vehículo</label>
                            <asp:DropDownList ID="ddlVehiculos" runat="server" DataValueField ="idVehiculo" DataTextField="dominio" CssClass="form-control input-sm col-md-offset-1" OnSelectedIndexChanged="ddlVehiculos_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">


                            <label for="ddlEstados" class="col-md-offset-1">Estados de Reparacion</label>
                            <asp:DropDownList ID="ddlEstados" runat="server" DataValueField ="idEstado" DataTextField ="nombreEstado" CssClass="form-control input-sm col-md-offset-1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">



                            <label for="rangoTotal">Total</label>

                            <div class="input-group input-group-sm" id="rangoTotal">

                                <span class="input-group-addon">Entre</span>
                                <asp:TextBox ID="txtTotalDesde" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon">y</span>
                                <asp:TextBox ID="txtTotalHasta" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            
                            <asp:CompareValidator ID="cvMontos" runat="server"
                                ControlToCompare="txtTotalDesde"
                                ControlToValidate="txtTotalHasta"
                                Operator="GreaterThanEqual" Type="Double"
                                Text="Ingrese un intervalo válido de montos" CssClass="text-danger" Display="Dynamic"></asp:CompareValidator>
                        <asp:CompareValidator ID="cvTotalDesde" runat ="server" ControlToValidate ="txtTotalDesde" Type="Double"
                             Text ="Ingrese montos válidos: formato xxxx,yy" CssClass="text-danger" Display ="Dynamic" ValidationGroup="montos"></asp:CompareValidator>
                            <asp:CompareValidator ID="cvTotalHasta" runat ="server" ControlToValidate ="txtTotalHasta" Type="Double"
                             Text ="Ingrese montos válidos: formato xxxx,yy" CssClass="text-danger" Display ="Dynamic" ValidationGroup="montos"></asp:CompareValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 ">
                        <div class="btn-group pull-right" role="group">
                            <asp:Button ID="btnFiltrar" CssClass="btn btn-success" Text="Filtrar" runat="server" OnClick="btnFiltrar_Click" />
                            <asp:Button ID="btnReset" runat="server" Text="Borrar Filtros" CssClass="btn btn-default" CausesValidation="false" OnClick="btnReset_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                Listado de Reparaciones
            </div>
                    <div class="panel-body">

                        <asp:GridView ID="gvReparaciones" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="gvReparaciones_PageIndexChanging" OnSorting="gvReparaciones_Sorting">
                            <Columns>
                                <asp:BoundField DataField="idReparacion" HeaderText="ID" Visible="false" />
                                <asp:BoundField DataField="vehiculo.dominio" HeaderText="Dominio" SortExpression="dominio" />
                                <asp:BoundField DataField="vehiculo.cliente.nombreCompleto" HeaderText="Cliente" SortExpression="apellido" />
                                <asp:BoundField DataField="estadoReparacion.nombreEstado" HeaderText="Estado" SortExpression="nombreEstado"  />
                                <asp:BoundField DataField="fechaFin" HeaderText="Fecha de Fin" SortExpression="fechaFin DESC" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="totalMO" HeaderText="Total" SortExpression="totalMO" DataFormatString="{0:C}" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


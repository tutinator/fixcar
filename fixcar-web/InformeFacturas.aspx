<%@ Page Title="Historial de Facturación" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="InformeFacturas.aspx.cs" Inherits="InformeFacturas" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h3>Historial de Facturación <small>Reporte de facturas emitidas por FixCar</small></h3>
        </div>
        <div class="panel panel-info">
            <div id="pheading1" class="panel-heading">
                <strong>Filtros</strong>
            </div>
            <div id="pbody1" class="panel-body">
                <div class="row">

                    <div class="col-md-4">
                        <div class="form-group">

                            <label for="rangoFechas">Fecha</label>

                            <div class="input-group input-group-sm" id="rangoFechas">

                                <span class="input-group-addon">Desde</span>
                                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon">Hasta</span>
                                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <asp:CompareValidator ID="cvFechas" runat="server"
                                ControlToValidate="txtFechaHasta"
                                ControlToCompare="txtFechaDesde"
                                Operator="GreaterThanEqual" Type="Date"
                                Text="Ingrese fechas válidas" CssClass="text-danger" Display="Dynamic"></asp:CompareValidator>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">


                            <label for="ddlCliente" class="col-md-offset-1">Propietario</label>
                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control input-sm col-md-offset-1"></asp:DropDownList>
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
                                ControlToValidate="txtTotalHasta"
                                ControlToCompare="txtTotalDesde"
                                Operator="GreaterThanEqual" Type="Currency"
                                Text="Ingrese montos válidos" CssClass="text-danger" Display="Dynamic"></asp:CompareValidator>
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
                Listado de Facturas
            </div>
                    <div class="panel-body">

                        <asp:GridView ID="gvFacturas" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="true" OnSorting="gvFacturas_Sorting" OnPageIndexChanging="gvFacturas_PageIndexChanging">
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
        </div>
    </div>
    <script>
        $(function () {
            $("[id$=txtFechaDesde]").datepicker({
                defaultDate: "-1m",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 3,
                maxDate: "+1D",
                dateFormat: 'dd/mm/yy',
                onClose: function (selectedDate) {
                    $("[id$=txtFechaHasta]").datepicker("option", "minDate", selectedDate);
                }
            });
            $("[id$=txtFechaHasta]").datepicker({
                defaultDate: "-1m",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 3,
                maxDate: "+1D",
                dateFormat: 'dd/mm/yy',
                onClose: function (selectedDate) {
                    $("[id$=txtFechaDesde]").datepicker("option", "maxDate", selectedDate);
                }
            });
        });

    </script>
</asp:Content>

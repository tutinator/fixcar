<%@ Page Title="Historial de Facturación" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="InformeFacturas.aspx.cs" Inherits="InformeFacturas" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />    
    <script src="Scripts/bootstrap.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />

    <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">--%>
    <script src="Scripts/jquery-1.11.3.min.js"></script>
    <script src="Scripts/jquery-ui-1.11.4.min.js"></script>
    <%--<link rel="stylesheet" href="/resources/demos/style.css">--%>

    <script>
        $(function () {
            $("#fechaDesde").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 3,
                onClose: function (selectedDate) {
                    $("#to").datepicker("option", "minDate", selectedDate);
                }
            });
            $("#fechaHasta").datepicker({
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 3,
                onClose: function (selectedDate) {
                    $("#from").datepicker("option", "maxDate", selectedDate);
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="page-header">
            <h3>Historial de Facturación</h3>
        </div>

        <div class="row">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-md-4">
                        <div class="form-group">

                            <label for="rangoFechas">Fecha</label>

                            <div class="input-group input-group-sm" id="rangoFechas">

                                <span class="input-group-addon">Desde</span>
                                <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon">Hasta</span>
                                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="ddlCliente" class="col-md-offset-1">Propietario</label>
                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control input-sm col-md-offset-1"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ControlToValidate="ddlCliente" InitialValue="0" Text="Seleccione un propietario" Display="Dynamic" CssClass="text-danger"></asp:RequiredFieldValidator>
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
                        </div>

                        <div class="col-md-12">
                            <div class="btn-group" role="group">
                            </div>
                        </div>

                    </div>
                </div>
            </div>
</div>

            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-md-12">
                            <asp:GridView ID="gvFacturas" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped table-responsive" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="true">
                                <Columns>
                                    <asp:BoundField DataField="idFactura" HeaderText="ID" Visible="false" />
                                    <asp:BoundField DataField="numeroFactura" HeaderText="Numero" SortExpression="numeroFactura" />
                                    <asp:BoundField DataField="fechaFactura" HeaderText="Fecha" SortExpression="fechaFactura" />
                                    <asp:BoundField DataField="reparacion.vehiculo.dominio" HeaderText="Dominio" SortExpression="vehiculo.dominio" />
                                    <asp:BoundField DataField="reparacion.vehiculo.cliente.nombreCompleto" HeaderText="Cliente" SortExpression="vehiculo.cliente.nombreCompleto" />
                                    <asp:BoundField DataField="reparacion.vehiculo.cliente.numeroDocumento" HeaderText="Documento" SortExpression="vehiculo.cliente.numeroDocumento" />
                                    <asp:BoundField DataField="reparacion.totalMO" HeaderText="Costo MO" SortExpression="reparacion.totalMO" />
                                    <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>

            </div>
    </div>

</asp:Content>

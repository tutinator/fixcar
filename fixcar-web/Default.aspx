<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>FixCar - Taller Mecánico</h1>
        <p class="lead">Taller mecánico dedicado a la reparación de automóviles y venta de repuestos.</p>
        <p><a href="Contact" class="btn btn-primary btn-lg">Contacto &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Gestión de Vehículos</h2>
            <p>
                Realizar una alta, baja, modificación o consulta de un vehículo y sus datos.
            </p>
            <p>
                <a class="btn btn-default" href="ABMCVehiculos">Ir &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Facturar</h2>
            <p>
               Registrar la facturación de una reparación realizada a un vehículo y de los repuestos utilizados.
            </p>
            <p>
                <a class="btn btn-default" href="Facturar">Ir &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Informe de Facturas</h2>
            <p>
                Informe de las facturas registradas mostrando los datos del cliente, el vehículo reparado, el monto de mano de obra y el monto total facturado.
            </p>
            <p>
                <a class="btn btn-default" href="InformeFacturas">Ir &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>

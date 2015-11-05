<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>FixCar - Taller Mecánico</h1>
        <p class="lead">Taller mecánico dedicado a la reparación de automóviles y venta de repuestos.</p>
<%--        <p><a href="Contact" class="btn btn-primary btn-lg">Contacto &raquo;</a></p>--%>
    </div>

     <%--Parte Trumba--%>
    <div class="row">
        <asp:Panel id="pGestionClientes" runat ="server" CssClass ="col-md-4" Visible ="false">
             <h2>Gestión de Clientes</h2>
            <p>
                Realizar una alta, baja, modificación o consulta de un vehículo y sus datos.
            </p>
            <p>
                <a class="btn btn-default" href="ABMClientes">Ir &raquo;</a>
            </p>
        </asp:Panel>

         <asp:Panel id="pRegReparacion" runat ="server" CssClass ="col-md-4" Visible ="false">
             <h2>Registrar Reparacion</h2>
            <p>
               Registrar la reparación a realizar para un vehículo con los trabajos a ejecutar. Permite presupuestar la reparación y conocer la fecha estimada de finalización de la misma.
            </p>
            <p>
                <a class="btn btn-default" href="RegistrarReparacion">Ir &raquo;</a>
            </p>
         </asp:Panel>
      
        <asp:Panel id="pInfoReparaciones" runat ="server" CssClass ="col-md-4" Visible ="false">
            <h2>Informe de Reparaciones</h2>
            <p>
                Informe de las reparaciones realizadas mostrando los datos del cliente, el vehículo reparado, la fecha de finalización y el monto de la mano de obra.
            </p>
            <p>
                <a class="btn btn-default" href="InformeReparaciones">Ir &raquo;</a>
            </p>
        </asp:Panel>
        
    </div>

    <div class="row">
        <asp:Panel id="pGestionVehiculos" runat ="server" CssClass ="col-md-4" Visible ="false">
            <h2>Gestión de Vehículos</h2>
            <p>
                Realizar una alta, baja, modificación o consulta de un vehículo y sus datos.
            </p>
            <p>
                <a class="btn btn-default" href="ABMCVehiculos">Ir &raquo;</a>
            </p>
        </asp:Panel>
      
        <asp:Panel id="pFacturar" runat ="server" CssClass ="col-md-4" Visible ="false">
            <h2>Facturar</h2>
            <p>
               Registrar la facturación de una reparación realizada a un vehículo y de los repuestos utilizados.
            </p>
            <p>
                <a class="btn btn-default" href="Facturar">Ir &raquo;</a>
            </p>
        </asp:Panel>
   
        <asp:Panel id="pInfoFacturas" runat ="server" CssClass ="col-md-4" Visible ="false">
                        <h2>Informe de Facturas</h2>
            <p>
                Informe de las facturas registradas mostrando los datos del cliente, el vehículo reparado, el monto de mano de obra y el monto total facturado.
            </p>
            <p>
                <a class="btn btn-default" href="InformeFacturas">Ir &raquo;</a>
            </p>
        </asp:Panel>
      
    </div>

   
</asp:Content>

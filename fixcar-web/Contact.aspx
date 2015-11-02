<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>FixCar</h3>
    <address>
        Armada Argentina 707<br />
        Córdoba Capital, 5014<br />
        <abbr title="Phone">P:</abbr>
        +54 9 351 4255552
    </address>

    <address>
        <strong>Ventas:</strong>   <a href="mailto:Support@example.com">ventas@fixcar.com</a><br />
        <strong>Consultas:</strong> <a href="mailto:Marketing@example.com">hola@fixcar.com</a>
    </address>
</asp:Content>

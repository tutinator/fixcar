<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pruebaJQuery.aspx.cs" MasterPageFile="~/Site.master" Inherits="pruebaJQuery" %>


<asp:Content id="Body" ContentPlaceHolderID="MainContent" runat="server">
      

    <div class="container">
        <div class="page-header">
            <h3>Historial de Facturación</h3>
        </div>

        <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtFecha" CssClass="col-md-2 control-label">Fecha:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox ID="txtFecha" runat="server" Text="" CssClass="datefield form-control"></asp:TextBox>
                    <asp:CompareValidator ID="cvtxtFecha" runat="server" ControlToValidate="txtFecha" Operator="DataTypeCheck" Type="Date" Text="Ingrese una fecha válida" CssClass="text-danger" Display="Dynamic" ValidationGroup="GrupoA"></asp:CompareValidator>
                </div>
            </div>
    </div>

    <script>
        $(function () {
            $("[id$=txtFecha]").datepicker({ dateFormat: 'dd-mm-yy' });
        });
    </script>
</asp:Content>

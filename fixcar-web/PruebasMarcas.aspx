<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebasMarcas.aspx.cs" Inherits="PruebasMarcas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    
        <asp:GridView ID="gvMarcas" runat="server" >
            <Columns>
                <asp:CommandField ShowSelectButton="True" />                
            </Columns>
        </asp:GridView>
        
    
    </div>
    </form>
</body>
</html>

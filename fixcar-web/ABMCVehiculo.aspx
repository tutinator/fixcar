<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ABMCVehiculo.aspx.cs" Inherits="ABMCVehiculo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Gestión de Vehículos</title>
    <script src="bootstrap.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server" class="container">

        
            <div class="page-header">
                <h1>Gestión de Vehículos</h1>
                </div>

                <div class="row">
                    <div class="col-md-8">
                        <asp:GridView ID="gvVehiculos" runat="server" CssClass="table table-hover table-bordered">


                        </asp:GridView>

                    </div>

                    <div class="col-md-4">

                        <div class="form-group">
                            <label for="dominio">Dominio</label>
                            <asp:TextBox ID="dominio" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="ddlCliente">Propietario</label>
                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlMarca">Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="km">Kilometraje</label>
                            <asp:TextBox ID="km" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="ano">Modelo</label>
                            <asp:TextBox ID="ano" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="checkbox form-group">
                            
                                <asp:CheckBox ID="cbPintura" runat="server" Text="Pintura Dañada"/>
                            
                            
                          
                        </div>



                    </div>



                </div>

           
            <footer class="footer">
                FIXCAR SW
            </footer>
       
    </form>

</body>
</html>

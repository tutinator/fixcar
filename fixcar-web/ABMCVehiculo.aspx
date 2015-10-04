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
                        <asp:GridView ID="gvVehiculos" runat="server" CssClass="table table-hover table-bordered table-condensed table-striped" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvVehiculos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="idVehiculo" HeaderText="idVehiculo" Visible="false" />
                                <asp:BoundField DataField="dominio" HeaderText="Dominio"/>
                                <asp:BoundField DataField="km" HeaderText="Kilometraje" />
                                <asp:BoundField DataField="pinturaDanada" HeaderText="Pintura Dañada" />
                                <asp:BoundField DataField="idMarca" HeaderText="Marca" />
                                <asp:BoundField DataField="idCliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="ano" HeaderText="Modelo" />
                                <asp:CommandField SelectText="Editar" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>

                    </div>

                    <div class="col-md-4">

                        <asp:TextBox ID="txtIdVehiculo" runat="server" Visible="false"></asp:TextBox>

                        <div class="form-group">
                            <label for="txtDominio">Dominio</label>
                            <asp:TextBox ID="txtDominio" runat="server" CssClass="form-control"></asp:TextBox>
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
                            <label for="txtKm">Kilometraje</label>
                            <asp:TextBox ID="txtKm" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtAno">Modelo</label>
                            <asp:TextBox ID="txtAno" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="checkbox form-group">
                        <asp:CheckBox ID="cbPintura" runat="server" Text="Pintura Dañada"/>
                                     </div>
                        <div class="btn-group" role="group">
                    
                        <asp:Button ID="btnGuardar"  CssClass="btn btn-success" Text="Guardar" runat="server"/>
                  
                        <button type="reset" class="btn btn-default" value="Limpiar">Limpiar</button>
                        </div>
                    </div>
                </div>           
            <footer class="footer">
                FIXCAR SW
            </footer>
       
    </form>
    
</body>
</html>

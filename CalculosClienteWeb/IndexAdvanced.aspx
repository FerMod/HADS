<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexAdvanced.aspx.cs" Inherits="CalculosClienteWeb.IndexAdvanced" Debug="false" Trace="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calcular Precio Factura</title>
    <style type="text/css">
        .auto-style1 {}
    </style>
</head>
<body style="margin: 0; height: 100%">
    <form id="form1" runat="server">
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Codigo de factura: </asp:Label>
            <br />
            <asp:TextBox ID="textBoxCodigoFactura" runat="server" Style="vertical-align: central; margin: 5px 5px 5px 0px;" Height="18px" Width="250px"></asp:TextBox>
            <asp:Button ID="botonBuscar" runat="server" Text="Buscar Factura" OnClick="BotonBuscar_Click" Width="120px" CssClass="auto-style1" Height="30px" />
        	<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBoxCodigoFactura" ErrorMessage="Este campo no puede estar vacío." Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <hr />
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Total: </asp:Label>
            <asp:Label ID="labelTotal" Style="vertical-align: central;" runat="server"></asp:Label>
        </div>
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Tipo de IVA: </asp:Label>
            <asp:Label ID="labelTipoIva" Style="vertical-align: central;" runat="server"></asp:Label>
        </div>
        <br />
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Total sin IVA: </asp:Label>
            <asp:Label ID="labelTotalSinIvaValue" Style="vertical-align: central;" runat="server"></asp:Label>
        </div>
        <div style="margin: 5px; padding: 5px">
            <asp:Label ID="labelIva" Style="vertical-align: central;" runat="server" Font-Bold="True">IVA (0%): </asp:Label>
            <asp:Label ID="labelIvaValue" Style="vertical-align: central;" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

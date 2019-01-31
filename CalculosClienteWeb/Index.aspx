<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CalculosClienteWeb.Index" Debug="false" Trace="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calcular Precio</title>
</head>
<body style="margin: 0; height: 100%">
    <form id="form1" runat="server">
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Total a pagar: </asp:Label>
            <br />
            <asp:TextBox ID="textBoxTotal" runat="server" Style="vertical-align: central; margin: 5px 5px 5px 0px;" Height="18px" Width="130px"></asp:TextBox>
        </div>
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Tipo de IVA: </asp:Label>
            <br />
            <asp:DropDownList ID="dropDownTipoIva" runat="server" Style="vertical-align: middle; margin: 5px 5px 5px 0px;" Height="20px" Width="130px"/>
        </div>
        <div style="margin: 5px; padding: 5px">
            <asp:Button ID="botonCalcular" runat="server" Text="Calcular" OnClick="BotonCalcular_Click" Width="89px" />
        </div>
        <hr />
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">Total sin IVA: </asp:Label><asp:Label ID="labelTotalSinIva" Style="vertical-align: central;" runat="server"></asp:Label>
        </div>
        <div style="margin: 5px; padding: 5px">
            <asp:Label Style="vertical-align: central;" runat="server" Font-Bold="True">IVA: </asp:Label><asp:Label ID="lablelIva" Style="vertical-align: central;" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

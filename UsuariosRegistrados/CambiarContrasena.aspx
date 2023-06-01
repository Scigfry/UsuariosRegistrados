<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarContrasena.aspx.cs" Inherits="UsuariosRegistrados.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtPasswordOld">Contraseña vieja:</label>
            <asp:TextBox ID="txtPasswordOld" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <label for="txtPassword">Contraseña:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <label for="txtRepetirPassword">Repetir contraseña:</label>
            <asp:TextBox ID="txtRepetirPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnRegistrar" runat="server" Text="Cambiar contraseña" OnClick="btnRegistrar_Click" />
            <asp:HyperLink ID="HyperLink1" runat="server" Visible="false">Verificar la cuenta</asp:HyperLink>
        </div>

        <div>
            <asp:Label runat="server" ID="lblMensaje"></asp:Label>
        </div>

        <div>
            <asp:Label runat="server" ID="lblError"></asp:Label>
        </div>
    </form>
</body>
</html>

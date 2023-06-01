<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContrasenaOlvidada.aspx.cs" Inherits="UsuariosRegistrados.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnPregunta" runat="server" Text="Obtener pregunta oculta" OnClick="btnPregunta_Click" />
        </div>

        <div>
            <label for="labelPregunta">Pregunta:</label>
            <asp:Label ID="labelPregunta" runat="server" ></asp:Label>
        </div>

        <div>
            <label for="txtRespuesta">Respuesta:</label>
            <asp:TextBox ID="txtRespuesta" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnModify" runat="server" Text="ModificarContraseña" OnClick="btnModify_Click"/>
        </div>

        <div>
            <asp:Label ID="lblContrasena" runat="server"></asp:Label>
        </div>

        <asp:HyperLink ID="lnkInicio" runat="server" Text="Pagina de inicio" NavigateUrl="Inicio.aspx"></asp:HyperLink>
    </form>
</body>
</html>

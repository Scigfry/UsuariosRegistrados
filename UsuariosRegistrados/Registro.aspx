<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="UsuariosRegistrados.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Usuario</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Registro de Usuario</h1>

            <div>
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>

            <div>
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>

            <div>
                <label for="txtApellidos">Apellidos:</label>
                <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
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
                <label for="txtGaldera">Galdera ezkutua:</label>
                <asp:TextBox ID="txtGaldera" runat="server"></asp:TextBox>
            </div>

            <div>
                <label for="txtErantzuna">Galderaren erantzuna:</label>
                <asp:TextBox ID="txtErantzuna" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                <!--<asp:Button ID="btnAtras" runat="server" Text="Atrás" OnClick="btnAtras_Click" />-->
                <asp:HyperLink ID="lnkInicio" runat="server" Text="Pagina de inicio" NavigateUrl="Inicio.aspx"></asp:HyperLink>
            </div>
            <div>
                <asp:Label runat="server" ID="lblMensaje"></asp:Label>
            </div>

            <div>
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </div>
        </div>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" Visible="false">Verificar la cuenta</asp:HyperLink>
        </p>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ViewTransporteVeloso.Form.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upnLogin">
            <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lbLogin" Text="Login:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbLogin"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" ID="lbSenha" Text="Senha:"></asp:Label>
                    <asp:TextBox runat="server" ID="tbSenha" TextMode="Password"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <asp:Button runat="server" ID="btnAutenticar" OnClick="btnAutenticar_Click" Text="Autenticar &raquo;" CssClass="btn btn-default" />
                </div>
            </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

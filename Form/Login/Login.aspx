<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ViewTransporteVeloso.Form.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login Transportes Veloso</title>
    <link rel="stylesheet" type="text/css" href="../../Content/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upnLogin">
            <ContentTemplate>
                <div class="container">
                    <a class="links" id="paracadastro"></a>
                    <a class="links" id="paralogin"></a>
                    <%--FORMULÁRIO DE LOGIN--%>
                    <div class="content">
                        <!--FORMULÁRIO DE LOGIN-->
                        <div id="login">
                            <form method="post" action="">
                                <h1>Transportes Veloso</h1>
                                <p>
                                    <label for="nome_login">Login:</label>
                                    <asp:TextBox runat="server" ID="tbLogin" placeholder="Digite seu e-mail"></asp:TextBox>
                                </p>

                                <p>
                                    <label for="email_login">Senha</label>
                                    <asp:TextBox runat="server" ID="tbSenha" TextMode="Password" placeholder="Digite seu email"></asp:TextBox>
                                </p>

                                <p>
                                    <input type="checkbox" name="manterlogado" id="manterlogado" value="" />
                                    <label for="manterlogado">Manter-me logado</label>
                                </p>

                                <p>
                                    <asp:Button runat="server" ID="btnAutenticar" OnClick="btnAutenticar_Click" Text="Autenticar &raquo;" value="logar" />
                                </p>

                                <p class="link">
                                    Ainda não tem conta?
                                    <a href="" runat="server" id="btnCadastrarUsuario" onserverclick="btnCadastrarUsuario_Click">Cadastre-se</a>
                                </p>
                            </form>
                        </div>


                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

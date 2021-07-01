<%@ Page Title="Registrar Novo Usuário" Language="C#" AutoEventWireup="true" CodeBehind="UsuarioPlataforma.aspx.cs" Inherits="ViewTransporteVeloso.Form.Usuario.UsuarioPlataforma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastrar Novo Usuário</title>
    <link rel="stylesheet" type="text/css" href="../../Content/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="upnUsuarioPlataforma">
            <ContentTemplate>
                <div class="container">
                    <a class="links" id="paracadastro"></a>
                    <a class="links" id="paralogin"></a>
                    <div class="content">
                        <!--FORMULÁRIO DE LOGIN-->
                        <div id="login">
                            <form method="post" action="">
                                <h1>Cadastro de Novo Usuário</h1>

                                <p>
                                    <label for="nome_cad">Seu nome:</label>
                                    <asp:TextBox runat="server" ID="tbNomeUsuario" placeholder="Digite seu nome completo" required="required"></asp:TextBox>
                                </p>

                                <p>
                                    <label for="email_cad">Seu e-mail:</label>
                                    <asp:TextBox runat="server" ID="tbLogin" placeholder="Digite seu e-mail" required="required"></asp:TextBox>
                                </p>

                                <p>
                                    <label for="email_cad">Seu Telefone:</label>
                                    <asp:TextBox runat="server" ID="tbTelefone" placeholder="ex: (99)99999-9999"></asp:TextBox>
                                </p>

                                <p>
                                    <label for="email_cad">Seu Endereço:</label>
                                    <asp:TextBox runat="server" ID="tbEndereço" placeholder="ex: Rua xxxx, nº 9999, Bairro xxxx, Cidade xxxx, Estado xx, Cep: 99.999-99"></asp:TextBox>
                                    <%--<input id="email_cad" name="email_cad" required="required" type="email" placeholder="contato@transportesVeloso.com" />--%>
                                </p>

                                <p>
                                    <label for="senha_cad">Sua senha:</label>
                                    <asp:TextBox runat="server" ID="tbSenha" TextMode="Password" placeholder="Digite sua senha"></asp:TextBox>
                                </p>

                                <p>
                                    <label for="senha_cad">Confirmar senha:</label>
                                    <asp:TextBox runat="server" ID="tbConfirmarSenha" TextMode="Password" placeholder="Digite novamente a sua senha"></asp:TextBox>
                                </p>

                                <p>
                                    <asp:Button runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" Text="Salvar &raquo;" value="logar" />
                                </p>

                                <p class="link">
                                    Já tem conta?
                                    <a href="" runat="server" id="btnVoltar" onserverclick="btnVoltarUsuario_Click">Voltar</a>
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

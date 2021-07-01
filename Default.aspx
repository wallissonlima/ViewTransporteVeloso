<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViewTransporteVeloso._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <%--<h1>TRANSPORTES VELOSO</h1>--%>
        <img src="Img/LogoTransportesVeloso.png" alt="">
        <%--<p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Veículos</h2>
            <%--<p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>--%>
            <p>
                Cadastre os veículos da empresa. Vincule eles aos contratos existentes. Emita relatórios para identificar a partis dos veículos cadastrados se o contrato está apresentando lucros ou prejuízos de acordo com os veículos vinculados a ele.
            </p>

            <p>
                <%--<a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>--%>
                <a class="btn btn-default" runat="server" href="~/Form/Veiculo/ManterVeiculo.aspx">Veículo &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Manutenção</h2>
            <%--<p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>--%>
            <p>
                Registre as manutenções feitas pelos veículos. Calcule os gastos que cada veículo de acordo com o período desejado.
            </p>
            <p>
                <%--<a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>--%>
                <a class="btn btn-default" runat="server" href="~/Form/Veiculo/ManterVeiculo.aspx">Manutenção &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Usuário</h2>
<%--            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>--%>
            <p>
                Acesse aqui para liberar acesso a usuários que solicitaram acesso ao sistema. Para acessar este módulo somente o administrador do sistema tem permissão.
            </p>
            <p>
                <%--<a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>--%>
                <a class="btn btn-default" runat="server" href="~/Form/Veiculo/ManterVeiculo.aspx">Usuário &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>

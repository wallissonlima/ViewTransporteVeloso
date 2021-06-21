<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoVeiculo.aspx.cs" Inherits="ViewTransporteVeloso.Form.TipoVeiculo.TipoVeiculo" %>

<asp:Content ID="TipoVeiculoContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upnManterTipoVeiculo" runat="server">
        <contenttemplate>
            <div class="jumbotron">
                <h1>Manter Tipo Veículo</h1>
                <p class="lead">Formulário responsável por cadastrar, editar, pesquisar e excluir o tipo veículo.</p>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <fieldset title="Pesquisar Tipo Veículo">
                        <legend>
                            <h2>Pesquisar Tipo Veículo</h2>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lbPlacaPesquisa">Descrição:</asp:Label>
                                    <asp:TextBox runat="server" ID="tbPlacaPesquisa" MaxLength="7"></asp:TextBox>
                                    <asp:Button runat="server" ID="btnPesquisar" OnClick="btnPesquisar_Click" Text="Pesquisar &raquo;" CssClass="btn btn-default" />
                                </div>
                            </div>
                        </legend>
                    </fieldset>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <fieldset title="Listar Veículo">
                        <legend>
                            <h2>Listar Tipo Veículo</h2>

                            <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                DataKeyNames="idTipoVeiculo" Font-Names="Verdana" Font-Size="10pt" ForeColor="#003366" GridLines="None"
                                ShowFooter="False" Style="vertical-align: top" Width="100%" OnSelectedIndexChanged="gvDados_SelectedIndexChanged"
                                OnRowCommand="gvDados_RowCommand" OnRowDataBound="gvDados_RowDataBound" OnPageIndexChanging="gvDados_PageIndexChanging" Visible="true">
                                <Columns>
                                    <asp:BoundField DataField="idTipoVeiculo" HeaderText="Código" Visible="false" />
                                    <asp:BoundField DataField="descricao" HeaderText="Placa" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnAlterar" runat="server"
                                                CommandName="Alterar" Text="Alterar"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idTipoVeiculo")%>' />

                                            <asp:Button ID="btnExcluir" runat="server"
                                                CommandName="Excluir" Text="Excluir"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idTipoVeiculo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#D3D3D3" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#49afcd" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" Font-Bold="false" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                <EmptyDataTemplate>
                                    <center>
                                        <literal id="ltDados" runat="server" foreColor="red" Text="Nenhum Registro Encontrado!"></literal>
                                    </center>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </legend>
                    </fieldset>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <fieldset>
                        <legend>
                            <h2 runat="server" id="hTitulo">Cadastrar Tipo Veículo</h2>
                        
                        <div class="row">
                            <div class="col-md-12">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lbDescricao">Descricao:</asp:Label></td>
                                        <td>
                                            <asp:HiddenField runat="server" ID="hfIdTipoVeiculo" />
                                            <asp:TextBox runat="server" ID="tbDescricao" MaxLength="7"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                            </legend>
                        </fieldset>
                    </div>
                <br />
                <p>
                    <%--<a runat="server" Onclick="btnSalvar_Click"  class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>--%>
                    <a runat="server" id="btnSalvar" onserverclick="btnSalvar_Click" class="btn btn-default">Salvar &raquo;</a>
                    <a runat="server" id="btnLimpar" onserverclick="btnLimpar_Click" class="btn btn-default">Limpar Formulário &raquo;</a>
                    <%--<asp:Button runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" Text="Salvar &raquo;" CssClass="btn btn-default" />--%>
                </p>

            </div>
        </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

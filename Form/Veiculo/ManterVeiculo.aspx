<%@ Page Title="Manter Veículo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManterVeiculo.aspx.cs" Inherits="ViewTransporteVeloso.Form.Veiculo.ManterVeiculo" %>

<asp:Content ID="VeiculoContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="upnManterVeiculo" runat="server">
        <ContentTemplate>
            <div class="jumbotron">
                <h1>Manter Veículo</h1>
                <p class="lead">Formulário responsável por cadastrar, editar, pesquisar e excluir veículos.</p>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <fieldset title="Pesquisar Veículo">
                        <legend>
                            <h2>Pesquisar Veículo</h2>

                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lbPlacaPesquisa">Placa:</asp:Label>
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
                            <h2>Listar Veículo</h2>

                            <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                DataKeyNames="idVeiculo" Font-Names="Verdana" Font-Size="10pt" ForeColor="#003366" GridLines="None"
                                ShowFooter="False" Style="vertical-align: top" Width="100%" OnSelectedIndexChanged="gvDados_SelectedIndexChanged"
                                OnRowCommand="gvDados_RowCommand" OnRowDataBound="gvDados_RowDataBound" OnPageIndexChanging="gvDados_PageIndexChanging" Visible="true">
                                <Columns>
                                    <asp:BoundField DataField="idVeiculo" HeaderText="Código" Visible="false" />
                                    <asp:BoundField DataField="placa" HeaderText="Placa" />
                                    <asp:BoundField DataField="descricaoTipoVeiculo" HeaderText="Tipo Veículo" />
                                    <asp:BoundField DataField="renavam" HeaderText="Renavam" />
                                    <asp:BoundField DataField="chassi" HeaderText="Chassi" />
                                    <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                                    <asp:BoundField DataField="zeroQuilometro" HeaderText="Zero Quilômetro" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnAlterar" runat="server"
                                                CommandName="Alterar" Text="Alterar"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idVeiculo")%>' />

                                            <asp:Button ID="btnExcluir" runat="server"
                                                CommandName="Excluir" Text="Excluir"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idVeiculo")%>' />
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
                            <h2 runat="server" id="hTitulo">Cadastrar Veículo</h2>
                        </legend>
                        <div class="row">
                            <div class="col-md-12">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lbPlaca">Placa:</asp:Label></td>
                                        <td>
                                            <asp:HiddenField runat="server" ID="hfIdVeiculo" />
                                            <asp:TextBox runat="server" ID="tbPlaca" MaxLength="7"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lbTipoVeiculo">Tipo Veículo:</asp:Label></td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlTipoVeiculo"></asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lbRenavam">Renavam:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="tbRenavam" MaxLength="11"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lbChassi">Chassi:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="tbChassi" MaxLength="17"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lbDescricao">Descricao:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="tbDescricao" MaxLength="500" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lbZeroQuilometro">Zero Quilômetro:</asp:Label></td>
                                        <td>
                                            <asp:CheckBox runat="server" ID="cbZeroQuilometro" Checked="false"></asp:CheckBox></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                </div>
                </fieldset>
                <br />
                <p>
                    <%--<a runat="server" Onclick="btnSalvar_Click"  class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>--%>
                    <a runat="server" id="btnSalvar" onserverclick="btnSalvar_Click" class="btn btn-default">Salvar &raquo;</a>
                    <a runat="server" id="btnLimpar" onserverclick="btnLimpar_Click" class="btn btn-default">Limpar Formulário &raquo;</a>
                    <%--<asp:Button runat="server" ID="btnSalvar" OnClick="btnSalvar_Click" Text="Salvar &raquo;" CssClass="btn btn-default" />--%>
                </p>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewTransporteVeloso.DO;
using ViewTransporteVeloso.Funcoes;

namespace ViewTransporteVeloso.Form.Pecas
{
    public partial class ManterPeca : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarPeca(string.Empty);
            hfIdPeca.Value = "0";

        }

        #region [GridView]
        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvDados.PageIndex = e.NewPageIndex;
        }

        protected void gvDados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DO.Peca objPeca = new DO.Peca();
            string idPeca = e.CommandArgument.ToString();

            switch (e.CommandName)
            {
                case "Alterar":
                    if (!String.IsNullOrEmpty(idPeca))
                    {
                        this.hTitulo.InnerText = "Alterar Peca";

                        objPeca = objPeca.GetPeca(null, int.Parse(idPeca)).FirstOrDefault();
                        if (objPeca != null)
                        {
                            hfIdPeca.Value = objPeca.IdPeca.ToString();
                            this.tbNome.Text = objPeca.Nome;
                            int.Parse(this.tbQuantidade.Text);
                            decimal.Parse(this.tbValor.Text);

                            this.tbNome.Enabled = false;
                        }
                    }
                    break;

                case "Excluir":

                    if (!String.IsNullOrEmpty(idPeca))
                    {
                        objPeca = objPeca.GetPeca(null, int.Parse(idPeca)).FirstOrDefault();

                        var retorno = objPeca.DeletePeca(objPeca.Nome, int.Parse(idPeca));
                        if (retorno == true)
                        {
                            CarregarPeca(string.Empty);
                            util.ShowMessage("Peça excluído com suscesso!", upnManterPeca);
                        }
                    }
                    break;
            }
        }
        #endregion

        #region [Button]
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DO.Peca objPeca = new DO.Peca();

            //Cadastro
            if (!string.IsNullOrWhiteSpace(hfIdPeca.Value) && hfIdPeca.Value == "0")
            {
                try
                {
                    objPeca.IdPeca = int.Parse(hfIdPeca.Value);
                    objPeca.Nome = this.tbNome.Text;
                    objPeca.Quantidade= int.Parse(this.tbQuantidade.Text);
                    objPeca.Valor = decimal.Parse(this.tbValor.Text);


                    objPeca.PutPeca(objPeca);

                    CarregarPeca(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Peça cadastrada com sucesso!", upnManterPeca);
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro cadastrar da peça! Favor entrar em contato com o administrador do sistema.", upnManterPeca);
                }
            }
            else
            {
                //Alteração
                try
                {
                    objPeca.IdPeca = int.Parse(hfIdPeca.Value);
                    objPeca.Nome = this.tbNome.Text;
                    objPeca.Quantidade = int.Parse(this.tbQuantidade.Text);
                    objPeca.Valor = decimal.Parse(this.tbValor.Text);

                    objPeca.PostPeca(objPeca);

                    CarregarPeca(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Veículo alterado com sucesso!", upnManterPeca);
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro ao alterar do Veículo! Favor entrar em contato com o administrador do sistema.", upnManterPeca);
                }
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.tbNomePesquisa.Text))
                {
                    CarregarPeca(this.tbNomePesquisa.Text);
                }
                else
                {
                    CarregarPeca(string.Empty);
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                util.ShowMessage("Erro ao efetuar a pesquisa! Favor entrar em contato com o administrador do sistema.", upnManterPeca);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }
        #endregion

        #region [MÉTODOS AUXILIARES]
        private void CarregarPeca(string nome)
        {
            DO.Peca objPeca = new DO.Peca();
            List<GRIDPeca> lstGridPeca = new List<GRIDPeca>();
            List<DO.Peca> lstPeca  = new List<DO.Peca>();

            if (string.IsNullOrEmpty(nome))
                lstPeca = objPeca.GetAll();
            else
                lstPeca = objPeca.GetPeca(nome);

            if (lstPeca.Count > 0)
            {

                foreach (var item in lstPeca)
                {
                    GRIDPeca objGridPeca = new GRIDPeca();
                    objGridPeca.IdPeca = item.IdPeca;


                    objGridPeca.Nome = item.Nome;
                    objGridPeca.Quantidade = item.Quantidade;
                    objGridPeca.Valor = item.Valor;

                    lstGridPeca.Add(objGridPeca);
                }

                this.gvDados.DataSource = lstGridPeca;
                this.gvDados.DataBind();
            }
            else
            {
                util.ShowMessage("Não foram encontrados peça com a descrição informada!", upnManterPeca);
            }
        }

        private void LimparFormulario()
        {
            hfIdPeca.Value = "0";
            this.tbNome.Text = string.Empty;
            this.tbQuantidade.Text = string.Empty;
            this.tbValor.Text = string.Empty;

            this.hTitulo.InnerText = "Cadastrar Peca";

            this.tbNome.Enabled = true;
        }
        #endregion
    }
}
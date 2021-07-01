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

namespace ViewTransporteVeloso.Form.MaoDeObra
{
    public partial class ManterMaoDeObra : System.Web.UI.Page
    {
        Util util = new Util();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarMaoDeObra(string.Empty);
                hfIdMaoDeObra.Value = "0";
            }
        }

        #region [GRIDVIEW]
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
            DO.MaoDeObra objMaoDeObra = new DO.MaoDeObra();
            string idMaoDeObra = e.CommandArgument.ToString();

            switch (e.CommandName)
            {
                case "Alterar":
                    if (!String.IsNullOrEmpty(idMaoDeObra))
                    {
                        this.hTitulo.InnerText = "Alterar Mao de obra";

                        objMaoDeObra = objMaoDeObra.GetMaoDeObra(null, int.Parse(idMaoDeObra)).FirstOrDefault();
                        if (objMaoDeObra != null)
                        {
                            hfIdMaoDeObra.Value = objMaoDeObra.IdMaoDeObra.ToString();
                            this.tbDescricao.Text = objMaoDeObra.Descricao;
                            this.tbValor.Text = objMaoDeObra.Valor.ToString();
                            this.tbValor.Text = objMaoDeObra.Valor.ToString();
                        }
                    }
                    break;

                case "Excluir":

                    if (!String.IsNullOrEmpty(idMaoDeObra))
                    {
                        objMaoDeObra = objMaoDeObra.GetMaoDeObra(null, int.Parse(idMaoDeObra)).FirstOrDefault();

                        var retorno = objMaoDeObra.DeleteMaoDeObra(objMaoDeObra.Descricao, int.Parse(idMaoDeObra));
                        if (retorno == true)
                        {
                            CarregarMaoDeObra(string.Empty);
                            util.ShowMessage("Mao de obra excluído com suscesso!", upnMaoDeObra);
                        }
                    }
                    break;
            }

        }
        #endregion

        #region [BUTTON]
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DO.MaoDeObra objMaoDeObra = new DO.MaoDeObra();

            //Cadastro
            if (!string.IsNullOrWhiteSpace(hfIdMaoDeObra.Value) && hfIdMaoDeObra.Value == "0")
            {
                try
                {
                    objMaoDeObra.IdMaoDeObra = int.Parse(hfIdMaoDeObra.Value);
                    objMaoDeObra.Descricao = this.tbDescricao.Text;
                    objMaoDeObra.Valor = decimal.Parse(this.tbValor.Text);


                    objMaoDeObra.PutMaoDeObra(objMaoDeObra);

                    CarregarMaoDeObra(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Mao de obra cadastrado com sucesso!", upnMaoDeObra);
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro cadastrar o Mao de obra! Favor entrar em contato com o administrador do sistema.", upnMaoDeObra);
                }
            }
            else
            {
                //Alteração
                try
                {
                    objMaoDeObra.IdMaoDeObra = int.Parse(hfIdMaoDeObra.Value);
                    objMaoDeObra.Descricao = this.tbDescricao.Text;
                    objMaoDeObra.Valor = decimal.Parse(this.tbValor.Text);

                    objMaoDeObra.PostMaoDeObra(objMaoDeObra);

                    CarregarMaoDeObra(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Mao de obra alterado com sucesso!", upnMaoDeObra);
                    
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro ao alterar do Mao de obra! Favor entrar em contato com o administrador do sistema.", upnMaoDeObra);
                }
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.tbDescricaoPesquisa.Text))
                {
                    CarregarMaoDeObra(this.tbDescricaoPesquisa.Text);
                }
                else
                {
                    CarregarMaoDeObra(string.Empty);
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                util.ShowMessage("Erro ao efetuar a pesquisa! Favor entrar em contato com o administrador do sistema.", upnMaoDeObra);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }
        #endregion

        #region [Métodos Auxiliares]
        private void CarregarMaoDeObra(string descricao)
        {
            DO.MaoDeObra objMaoDeObra = new DO.MaoDeObra();
            List<GRIDMaoDeObra> lstGridMaoDeObra = new List<GRIDMaoDeObra>();
            List<DO.MaoDeObra> lstMaoDeObra = new List<DO.MaoDeObra>();

            if (string.IsNullOrEmpty(descricao))
                lstMaoDeObra = objMaoDeObra.GetAll();
            else
                lstMaoDeObra = objMaoDeObra.GetMaoDeObra(descricao);

            if (lstMaoDeObra.Count > 0)
            {

                foreach (var item in lstMaoDeObra)
                {
                    GRIDMaoDeObra objGridMaoDeObra = new GRIDMaoDeObra();
                    objGridMaoDeObra.IdMaoDeObra = item.IdMaoDeObra;


                    objGridMaoDeObra.Descricao = item.Descricao;
                    objGridMaoDeObra.Valor = item.Valor;

                    lstGridMaoDeObra.Add(objGridMaoDeObra);
                }

                this.gvDados.DataSource = lstGridMaoDeObra;
                this.gvDados.DataBind();
            }
            else
            {
                util.ShowMessage("Não foram encontrados mao de obra com a descrição informada!", upnMaoDeObra);
            }
        }

        private void LimparFormulario()
        {
            hfIdMaoDeObra.Value = "0";

            this.tbDescricao.Text = string.Empty;
            this.tbValor.Text = string.Empty;

            this.hTitulo.InnerText = "Cadastrar MaoDeObra";

            //this.tbDescricao.Enabled = true;
        }
        #endregion
    }
}

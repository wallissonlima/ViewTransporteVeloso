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


namespace ViewTransporteVeloso.Form.TipoVeiculo
{
    public partial class TipoVeiculo : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarTipoVeiculo(string.Empty);
                hfIdTipoVeiculo.Value = "0";
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
            DO.TipoVeiculo objTipoVeiculo = new DO.TipoVeiculo();
            string idTipoVeiculo = e.CommandArgument.ToString();

            switch (e.CommandName)
            {
                case "Alterar":
                    if (!String.IsNullOrEmpty(idTipoVeiculo))
                    {
                        this.hTitulo.InnerText = "Alterar Tipo Veículo";

                        objTipoVeiculo = objTipoVeiculo.GetTipoVeiculo(null, int.Parse(idTipoVeiculo)).FirstOrDefault();
                        if (objTipoVeiculo != null)
                        {
                            hfIdTipoVeiculo.Value = objTipoVeiculo.IdTipoVeiculo.ToString();
                            this.tbDescricao.Text = objTipoVeiculo.Descricao;

                            this.tbDescricao.Enabled = false;
                        }
                    }
                    break;

                case "Excluir":

                    if (!String.IsNullOrEmpty(idTipoVeiculo))
                    {
                        objTipoVeiculo = objTipoVeiculo.GetTipoVeiculo(null, int.Parse(idTipoVeiculo)).FirstOrDefault();

                        var retorno = objTipoVeiculo.DeleteTipoVeiculo(objTipoVeiculo.Descricao, int.Parse(idTipoVeiculo));
                        if (retorno == true)
                        {
                            CarregarTipoVeiculo(string.Empty);
                            util.ShowMessage("Tipo veículo excluído com suscesso!", upnTipoVeiculo);
                        }
                    }
                    break;
            }

        }
        #endregion

        #region [BUTTON]
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DO.TipoVeiculo objTipoVeiculo = new DO.TipoVeiculo();

            //Cadastro
            if (!string.IsNullOrWhiteSpace(hfIdTipoVeiculo.Value) && hfIdTipoVeiculo.Value == "0")
            {
                try
                {
                    objTipoVeiculo.IdTipoVeiculo = int.Parse(hfIdTipoVeiculo.Value);
                    objTipoVeiculo.Descricao = this.tbDescricao.Text;

                    objTipoVeiculo.PutTipoVeiculo(objTipoVeiculo);

                    CarregarTipoVeiculo(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Tipo Veículo cadastrado com sucesso!", upnTipoVeiculo);
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro cadastrar o Tipo Veículo! Favor entrar em contato com o administrador do sistema.", upnTipoVeiculo);
                }
            }
            else
            {
                //Alteração
                try
                {
                    objTipoVeiculo.IdTipoVeiculo = int.Parse(hfIdTipoVeiculo.Value);
                    objTipoVeiculo.Descricao = this.tbDescricao.Text;

                    objTipoVeiculo.PostTipoVeiculo(objTipoVeiculo);

                    CarregarTipoVeiculo(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Tipo Veículo alterado com sucesso!", upnTipoVeiculo);
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro ao alterar do Tipo Veículo! Favor entrar em contato com o administrador do sistema.", upnTipoVeiculo);
                }
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.tbDescricaoPesquisa.Text))
                {
                    CarregarTipoVeiculo(this.tbDescricaoPesquisa.Text);
                }
                else
                {
                    CarregarTipoVeiculo(string.Empty);
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                util.ShowMessage("Erro ao efetuar a pesquisa! Favor entrar em contato com o administrador do sistema.", upnTipoVeiculo);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }
        #endregion

        #region [Métodos Auxiliares]
        private void CarregarTipoVeiculo(string descricao)
        {
            DO.TipoVeiculo objTipoVeiculo = new DO.TipoVeiculo();
            List<GRIDTipoVeiculo> lstGridTipoVeiculo = new List<GRIDTipoVeiculo>();
            List<DO.TipoVeiculo> lstTipoVeiculo = new List<DO.TipoVeiculo>();

            if (string.IsNullOrEmpty(descricao))
                lstTipoVeiculo = objTipoVeiculo.GetAll();
            else
                lstTipoVeiculo = objTipoVeiculo.GetTipoVeiculo(descricao);

            if (lstTipoVeiculo.Count > 0)
            {

                foreach (var item in lstTipoVeiculo)
                {
                    GRIDTipoVeiculo objGridTipoVeiculo = new GRIDTipoVeiculo();
                    objGridTipoVeiculo.IdTipoVeiculo = item.IdTipoVeiculo;

                   
                    objGridTipoVeiculo.Descricao = item.Descricao;

                    lstGridTipoVeiculo.Add(objGridTipoVeiculo);
                }

                this.gvDados.DataSource = lstGridTipoVeiculo;
                this.gvDados.DataBind();
            }
            else
            {
                util.ShowMessage("Não foram encontrados Tipo veículo com a descrição informada!", upnTipoVeiculo);
            }
        }
        private void LimparFormulario()
        {
            hfIdTipoVeiculo.Value = "0";

            this.tbDescricao.Text = string.Empty;

            this.hTitulo.InnerText = "Cadastrar Veículo";

            this.tbDescricao.Enabled = true;
        }
        #endregion
    }
}
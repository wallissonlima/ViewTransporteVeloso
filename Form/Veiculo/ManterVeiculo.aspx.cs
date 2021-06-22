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

namespace ViewTransporteVeloso.Form.Veiculo
{
    public partial class ManterVeiculo : System.Web.UI.Page
    {
        Util util = new Util();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarVeiculos(string.Empty);
                CarregarTipoVeiculo();
                hfIdVeiculo.Value = "0";
            }
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
            DO.Veiculo objVeiculo = new DO.Veiculo();
            string idVeiculo = e.CommandArgument.ToString();

            switch (e.CommandName)
            {
                case "Alterar":
                    if (!String.IsNullOrEmpty(idVeiculo))
                    {
                        this.hTitulo.InnerText = "Alterar Veículo";

                        objVeiculo = objVeiculo.GetVeiculo(null, int.Parse(idVeiculo)).FirstOrDefault();
                        if (objVeiculo != null)
                        {
                            hfIdVeiculo.Value = objVeiculo.IdVeiculo.ToString();
                            this.tbPlaca.Text = objVeiculo.Placa;
                            this.ddlTipoVeiculo.SelectedValue = objVeiculo.IdTipoVeiculo.ToString();
                            this.tbRenavam.Text = objVeiculo.Renavam;
                            this.tbChassi.Text = objVeiculo.Chassi;
                            this.tbDescricao.Text = objVeiculo.Descricao;
                            this.cbZeroQuilometro.Checked = objVeiculo.ZeroQuilometro;

                            this.tbPlaca.Enabled = false;
                        }
                    }
                    break;

                case "Excluir":

                    if (!String.IsNullOrEmpty(idVeiculo))
                    {
                        objVeiculo = objVeiculo.GetVeiculo(null, int.Parse(idVeiculo)).FirstOrDefault();

                        var retorno = objVeiculo.DeleteVeiculo(objVeiculo.Placa, int.Parse(idVeiculo));
                        if (retorno == true)
                        {
                            CarregarVeiculos(string.Empty);
                            util.ShowMessage("Veículo excluído com suscesso!", upnManterVeiculo);
                        }
                    }
                    break;
            }
        }
        #endregion

        #region [Button]
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            DO.Veiculo objVeiculo = new DO.Veiculo();

            //Cadastro
            if (!string.IsNullOrWhiteSpace(hfIdVeiculo.Value) && hfIdVeiculo.Value == "0")
            {
                try
                {
                    objVeiculo.IdVeiculo = int.Parse(hfIdVeiculo.Value);
                    objVeiculo.Placa = this.tbPlaca.Text;
                    objVeiculo.IdTipoVeiculo = int.Parse(this.ddlTipoVeiculo.SelectedValue);
                    objVeiculo.Renavam = this.tbRenavam.Text;
                    objVeiculo.Chassi = this.tbChassi.Text;
                    objVeiculo.Descricao = this.tbDescricao.Text;
                    objVeiculo.ZeroQuilometro = this.cbZeroQuilometro.Checked;

                    objVeiculo.PutVeiculo(objVeiculo);

                    CarregarVeiculos(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Veículo cadastrado com sucesso!", upnManterVeiculo);
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro cadastrar o Veículo! Favor entrar em contato com o administrador do sistema.", upnManterVeiculo);
                }
            }
            else
            {
                //Alteração
                try
                {
                    objVeiculo.IdVeiculo = int.Parse(hfIdVeiculo.Value);
                    objVeiculo.Placa = this.tbPlaca.Text;
                    objVeiculo.IdTipoVeiculo = int.Parse(this.ddlTipoVeiculo.SelectedValue);
                    objVeiculo.Renavam = this.tbRenavam.Text;
                    objVeiculo.Chassi = this.tbChassi.Text;
                    objVeiculo.Descricao = this.tbDescricao.Text;
                    objVeiculo.ZeroQuilometro = this.cbZeroQuilometro.Checked;

                    objVeiculo.PostVeiculo(objVeiculo);

                    CarregarVeiculos(string.Empty);
                    LimparFormulario();
                    util.ShowMessage("Veículo alterado com sucesso!", upnManterVeiculo);
                }
                catch (Exception ex)
                {
                    var test = ex.Message;
                    util.ShowMessage("Erro ao alterar do Veículo! Favor entrar em contato com o administrador do sistema.", upnManterVeiculo);
                }
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.tbPlacaPesquisa.Text))
                {
                    CarregarVeiculos(this.tbPlacaPesquisa.Text);
                }
                else
                {
                    CarregarVeiculos(string.Empty);
                }
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                util.ShowMessage("Erro ao efetuar a pesquisa! Favor entrar em contato com o administrador do sistema.", upnManterVeiculo);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }
        #endregion

        #region [MÉTODOS AUXILIARES]
        private void CarregarVeiculos(string placa)
        {
            DO.Veiculo objVeiculo = new DO.Veiculo();
            List<GRIDVeiculo> lstGridVeiculo = new List<GRIDVeiculo>();
            List<DO.Veiculo> lstVeiculo = new List<DO.Veiculo>();

            if (string.IsNullOrEmpty(placa))
                lstVeiculo = objVeiculo.GetAll();
            else
                lstVeiculo = objVeiculo.GetVeiculo(placa);

            if (lstVeiculo.Count > 0)
            {

                foreach (var item in lstVeiculo)
                {
                    GRIDVeiculo objGridVeiculo = new GRIDVeiculo();
                    objGridVeiculo.IdVeiculo = item.IdVeiculo;

                    DO.TipoVeiculo objTipoVeiculo = new DO.TipoVeiculo();
                    var vDescricao = objTipoVeiculo.GetTipoVeiculo(item.IdTipoVeiculo).FirstOrDefault().Descricao;
                    if (!string.IsNullOrWhiteSpace(vDescricao))
                        objGridVeiculo.DescricaoTipoVeiculo = vDescricao;
                    else
                        objGridVeiculo.DescricaoTipoVeiculo = "-";

                    objGridVeiculo.Placa = item.Placa;
                    objGridVeiculo.Renavam = item.Renavam;
                    objGridVeiculo.Chassi = item.Chassi;
                    objGridVeiculo.Descricao = item.Descricao;
                    objGridVeiculo.ZeroQuilometro = item.ZeroQuilometro;

                    lstGridVeiculo.Add(objGridVeiculo);
                }

                this.gvDados.DataSource = lstGridVeiculo;
                this.gvDados.DataBind();
            }
            else
            {
                util.ShowMessage("Não foram encontrados veículos com a placa informada!", upnManterVeiculo);
            }
        }

        private void CarregarTipoVeiculo()
        {
            DO.TipoVeiculo objTipoVeiculo = new DO.TipoVeiculo();

            this.ddlTipoVeiculo.DataValueField = "idTipoVeiculo";
            this.ddlTipoVeiculo.DataTextField = "descricao";
            this.ddlTipoVeiculo.DataSource = objTipoVeiculo.GetAll();
            this.ddlTipoVeiculo.DataBind();
            this.ddlTipoVeiculo.Items.Add(new ListItem("Selecione...", "0"));
            this.ddlTipoVeiculo.SelectedValue = "0";
        }

        private void LimparFormulario()
        {
            hfIdVeiculo.Value = "0";
            this.tbPlaca.Text = string.Empty;
            this.ddlTipoVeiculo.SelectedValue = "0";
            this.tbRenavam.Text = string.Empty;
            this.tbChassi.Text = string.Empty;
            this.tbDescricao.Text = string.Empty;
            this.cbZeroQuilometro.Checked = false;

            this.hTitulo.InnerText = "Cadastrar Veículo";

            this.tbPlaca.Enabled = true;
        }
        #endregion
    }
}
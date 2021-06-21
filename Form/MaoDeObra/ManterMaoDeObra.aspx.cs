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
                CarregarMaoDeObra();
            }
        }

        #region [GRIDVIEW]
        protected void gvDados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //this.gvDados.PageIndex = e.NewPageIndex;
        }

        protected void gvDados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void gvDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }
        #endregion

        #region [BUTTON]
        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region [Métodos Auxiliares]
        private void CarregarMaoDeObra()
        {
            DO.MaoDeObra objMaoDeObra = new DO.MaoDeObra();
            var lstMaoDeObra = objMaoDeObra.GetAll();

        }
        #endregion
    }
}

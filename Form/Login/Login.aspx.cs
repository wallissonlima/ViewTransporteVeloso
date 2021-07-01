using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewTransporteVeloso.Funcoes;

namespace ViewTransporteVeloso.Form.Login
{
    public partial class Login : System.Web.UI.Page
    {
        Util util = new Util();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAutenticar_Click(object sender, EventArgs e)
        {
            DO.Usuario usuario = new DO.Usuario();
            string cripitografia = util.getHashSha256(this.tbSenha.Text);

            var objUsuario = usuario.GetAutenticar(this.tbLogin.Text, cripitografia);
            if(objUsuario != null)
                Response.Redirect("https://localhost:44311/");
            else
                util.ShowMessage("Usuário ou Senha Inválido!", upnLogin);
        }
    }
}
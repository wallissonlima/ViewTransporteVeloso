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

            //Criptografa a senha. 
            string criptografia = util.getHashSha256(this.tbSenha.Text);

            //var objUsuario = usuario.GetAutenticar(this.tbLogin.Text, this.tbSenha.Text);
            var objUsuario = usuario.GetAutenticar(this.tbLogin.Text, criptografia);
            if (objUsuario != null)
                Response.Redirect("https://localhost:44311/");
            else
                util.ShowMessage("Usuário ou Senha Inválido!", upnLogin);
        }

        protected void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            util.ShowMessage("Infelizmente a tela de cadastro de usuário ainda não foi desenvolvida! :(", upnLogin);
        }
    }
}
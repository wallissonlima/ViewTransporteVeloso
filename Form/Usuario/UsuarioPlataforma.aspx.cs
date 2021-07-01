using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewTransporteVeloso.Funcoes;

namespace ViewTransporteVeloso.Form.Usuario
{
    public partial class UsuarioPlataforma : System.Web.UI.Page
    {
        Util util = new Util();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44311/Form/Login/Login.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarSenha(this.tbSenha.Text, this.tbConfirmarSenha.Text) == true)
            {
                DO.Usuario objUsuario = new DO.Usuario();
                objUsuario.Nome = this.tbNomeUsuario.Text;
                objUsuario.Email = this.tbLogin.Text;
                objUsuario.Telefone = this.tbTelefone.Text;
                objUsuario.Endereço = this.tbEndereço.Text;
                objUsuario.Senha = util.getHashSha256(this.tbSenha.Text);
                objUsuario.IdPerfilUsuario = null;
                objUsuario.Autorizado = false;

                if (objUsuario.PutUsuario(objUsuario) == true)
                {
                    util.ShowMessage("Usuário cadastrado com sucesso!", upnUsuarioPlataforma);
                    Response.Redirect("https://localhost:44311/Form/Login/Login.aspx");
                }
                else {
                    util.ShowMessage("Erro ao cadastrar o usuário! Tente novamente, se o erro persistir entre em contato com o administrador do sistema.", upnUsuarioPlataforma);
                }
            }
            else
            {
                util.ShowMessage("Senha digitada é diferente do campo confirmar senha!", upnUsuarioPlataforma);
            }
        }

        private bool ValidarSenha(string senha, string confirmarSenha)
        {
            string senhaCriptografada = util.getHashSha256(this.tbSenha.Text);
            string novaSenhaCriptografada = util.getHashSha256(this.tbConfirmarSenha.Text);

            if (senhaCriptografada == novaSenhaCriptografada)
                return true;
            else
                return false;
        }
    }
}
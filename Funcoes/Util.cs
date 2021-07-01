using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;

namespace ViewTransporteVeloso.Funcoes
{
    public class Util
    {
        public void ShowMessage(string msg, Control controle)
        {
            ScriptManager.RegisterStartupScript(controle, controle.GetType(), Guid.NewGuid().ToString(), string.Format("alert('{0}');", msg), true);
        }

        public void MessageOKCancel(string msg, Control controle)
        {
            ScriptManager.RegisterStartupScript(controle, controle.GetType(), Guid.NewGuid().ToString(), string.Format("var r = window.confirm('{0}');", msg), true);
        }

        public bool SendEmail(string vRemetente, string vDestinatario, string vAssunto, string vMensagem)
        {
            //<add key="SMTPHost" value="smtp.gmail.com"/>
            //<add key="SMTPPort" value="587"/>
            //<add key="SMTPUser" value="suporte@neocom.info"/>
            //<add key="SMTPPass" value="maloc666"/>

            bool vEmailEnviado = false;
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587 /*TLS*/);
            cliente.EnableSsl = true;

            MailAddress remetente = new MailAddress(vRemetente, "Remetente");
            MailAddress destinatario = new MailAddress(vDestinatario, "Destinatario");
            MailMessage mensagem = new MailMessage(remetente, destinatario);

            mensagem.Subject = vAssunto;
            mensagem.Body = vMensagem;
            mensagem.IsBodyHtml = true;
            mensagem.Priority = MailPriority.High;

            cliente.Credentials = new System.Net.NetworkCredential("suporte@neocom.info", "maloc666");

            try
            {
                cliente.Send(mensagem);
                vEmailEnviado = true;
            }
            catch (Exception)
            {
                vEmailEnviado = false;
                throw;
            }

            return vEmailEnviado;
        }

        #region script
        public string Criptografa(string cChave)
        {
            string cChaveCripto;
            Byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(cChave);
            cChaveCripto = Convert.ToBase64String(b);
            return cChaveCripto;
        }

        public string Decriptografa(string cChaveCripto)
        {
            string cChaveDecripto;
            Byte[] b = Convert.FromBase64String(cChaveCripto);
            cChaveDecripto = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return cChaveDecripto;
        }
        #endregion

        public string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            System.Security.Cryptography.SHA256Managed hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static string RetornarHash(byte[] Hash)
        {
            System.Security.Cryptography.SHA256Managed hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = hashstring.ComputeHash(Hash);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
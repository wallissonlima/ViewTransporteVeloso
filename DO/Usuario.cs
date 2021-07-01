using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace ViewTransporteVeloso.DO
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereço { get; set; }
        public string Senha { get; set; }
        public int? IdPerfilUsuario { get; set; }
        public bool Autorizado { get; set; }


        public Usuario GetAutenticar(string email = null, string senha = null)
        {
            Usuario objUsuario = new Usuario();
            objUsuario.Email = email;
            objUsuario.Senha = senha;

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var vPath = "Usuario/GetAutenticar?email=" + email +
                        "&senha=" + senha;

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + vPath);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<DO.Usuario>(streamReader.ReadToEnd());
                objUsuario = retornoAPI;
            }

            //Fecha a requisição existente
            if (httpResponse != null)
            {
                httpResponse.Dispose();
                httpResponse.Close();
            }

            //Retorna do valor
            return objUsuario;
        }

        public bool PutUsuario(Usuario usuario)
        {

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "Usuario/PutUsuario?" +
                                "nome=" + usuario.Nome +
                                "&email=" + usuario.Email +
                                "&telefone=" + usuario.Telefone +
                                "&endereco=" + usuario.Endereço +
                                "&senha=" + usuario.Senha +
                                "&idPerfilUsuario=" + usuario.IdPerfilUsuario +
                                "&autorizado=" + usuario.Autorizado;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + PerfilPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";

                //Necessário para requisições do tipo PUT e POST
                var bytes = Encoding.ASCII.GetBytes(PerfilPath);
                using (var requestStream = httpWebRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Desserializa o objeto convertendo em formato Json. 
                    var retornoAPI = JsonConvert.DeserializeObject<String>(streamReader.ReadToEnd());
                    if (!string.IsNullOrEmpty(retornoAPI) && retornoAPI == "Success")
                    {
                        httpResponse.Dispose();
                        httpResponse.Close();
                        return true;
                    }
                    else
                    {
                        httpResponse.Dispose();
                        httpResponse.Close();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
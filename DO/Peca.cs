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
    public class Peca
    {
        public int IdPeca { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public Decimal Valor { get; set; }

        #region [REQUISIÇÕES HTTPS]
        public List<Peca> GetAll()
        {
            List<Peca> lstPeca = new List<Peca>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var vPath = "Peca/GetAll";

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + vPath);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.Peca>>(streamReader.ReadToEnd()).ToList();
                lstPeca = retornoAPI;
            }

            //Fecha a requisição existente
            if (httpResponse != null)
            {
                httpResponse.Dispose();
                httpResponse.Close();
            }

            //Retorna do valor
            return lstPeca;
        }

        public List<Peca> GetPeca(string nome = null, int idPeca = 0)
        {
            List<Peca> lstPeca = new List<Peca>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var vPath = "Peca/GetPeca?nome=" + nome +
                        "&idPeca=" + idPeca;

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + vPath);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.Peca>>(streamReader.ReadToEnd()).ToList();
                lstPeca = retornoAPI;
            }

            //Fecha a requisição existente
            if (httpResponse != null)
            {
                httpResponse.Dispose();
                httpResponse.Close();
            }

            //Retorna do valor
            return lstPeca;
        }

        public bool DeletePeca(string nome = "", int idPeca = 0)
        {
            try
            {
                //Recupera o endereço do serviço e monta a requisição. 
                string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
                string vPath = "Peca/DeletePeca?nome=" + nome +
                               "&idPeca=" + idPeca;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + vPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    //Obtem a resposta e desserializa o objeto Json.
                    var retornoAPI = JsonConvert.DeserializeObject<bool>(streamReader.ReadToEnd());
                    return retornoAPI;
                }

                //Fecha a requisição existente
                if (httpResponse != null)
                {
                    httpResponse.Dispose();
                    httpResponse.Close();
                }

                //Retorna do valor
                return true;

            }
            catch (Exception ex)
            {
                var vError = ex.Message;
                return false;
            }

        }

        /// <summary>
        /// Altera um Peças existente
        /// </summary>
        /// <param name="peca"></param>
        /// <returns></returns>
        public bool PostPeca(Peca peca)
        {
            Peca objPeca = new Peca();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "Peca/PostPeca?" +
                                "idPeca=" + peca.IdPeca +
                                "&nome=" + peca.Nome +
                                "&quantidade=" + peca.Quantidade +
                                "&valor=" + peca.Valor;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + PerfilPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

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

        /// <summary>
        /// Insere um nova peça
        /// </summary>
        /// <param name="peca"></param>
        /// <returns></returns>
        public bool PutPeca(Peca peca)
        {
            Peca objPeca = new Peca();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "Peca/PutPeca?" +
                                "&nome=" + peca.Nome +
                                "&quantidade=" + peca.Quantidade +
                                "&valor=" + peca.Valor;
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
        #endregion
    }

    public class GRIDPeca
    {
        public int IdPeca { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public Decimal Valor { get; set; }
    }
}
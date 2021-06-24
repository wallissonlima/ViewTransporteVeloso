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
    public class TipoVeiculo
    {
        public int IdTipoVeiculo { get; set; }
        public string Descricao { get; set; }

        #region
        public List<TipoVeiculo> GetAll()
        {
            List<TipoVeiculo> lstVeiculo = new List<TipoVeiculo>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var urlPreenchida = ApiBaseUrl + "TipoVeiculo/GetAll";

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlPreenchida);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.TipoVeiculo>>(streamReader.ReadToEnd()).ToList();
                lstVeiculo = retornoAPI;
            }

            //Fecha a requisição existente
            if (httpResponse != null)
            {
                httpResponse.Dispose();
                httpResponse.Close();
            }

            //Retorna do valor
            return lstVeiculo;
        }

        public List<TipoVeiculo> GetTipoVeiculo(string descricao = null, int idTipoVeiculo = 0)
        {
            List<TipoVeiculo> lstTipoVeiculo = new List<TipoVeiculo>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var vPath = "TipoVeiculo/GetTipoVeiculo?descricao=" + descricao +
                        "&idTipoVeiculo=" + idTipoVeiculo;

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + vPath);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.TipoVeiculo>>(streamReader.ReadToEnd()).ToList();
                lstTipoVeiculo = retornoAPI;
            }

            //Fecha a requisição existente
            if (httpResponse != null)
            {
                httpResponse.Dispose();
                httpResponse.Close();
            }

            //Retorna do valor
            return lstTipoVeiculo;
        }

        public bool DeleteTipoVeiculo(string descricao = "", int idTipoVeiculo = 0)
        {
            try
            {
                //Recupera o endereço do serviço e monta a requisição. 
                string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
                string vPath = "TipoVeiculo/DeleteTipoVeiculo?descricao=" + descricao +
                               "&idTipoVeiculo=" + idTipoVeiculo;

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
        /// Altera um veículo existente
        /// </summary>
        /// <param name="tipoVeiculo"></param>
        /// <returns></returns>
        public bool PostTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            TipoVeiculo objTipoVeiculo = new TipoVeiculo();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "TipoVeiculo/PostTipoVeiculo?" +
                                "idTipoVeiculo=" + tipoVeiculo.IdTipoVeiculo +
                                "&descricao=" + tipoVeiculo.Descricao;

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
        /// Insere um novo veículo
        /// </summary>
        /// <param name="tipoVeiculo"></param>
        /// <returns></returns>
        public bool PutTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            TipoVeiculo objTipoVeiculo = new TipoVeiculo();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "TipoVeiculo/PutTipoVeiculo?" +
                                "&descricao=" + tipoVeiculo.Descricao;

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

    public class GRIDTipoVeiculo
    {
        public int IdTipoVeiculo { get; set; }
        public string Descricao { get; set; }
 
    }
}
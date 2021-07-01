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
    public class MaoDeObra
    {
        public int IdMaoDeObra { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }

        #region
        public List<MaoDeObra> GetAll()
        {
            List<MaoDeObra> lstMaoDeObra = new List<MaoDeObra>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var urlPreenchida = ApiBaseUrl + "MaoDeObra/GetAll";

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlPreenchida);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.MaoDeObra>>(streamReader.ReadToEnd()).ToList();
                lstMaoDeObra = retornoAPI;
            }

            //Fecha a requisição existente
            if (httpResponse != null)
            {
                httpResponse.Dispose();
                httpResponse.Close();
            }

            //Retorna do valor
            return lstMaoDeObra;
        }

        public List<MaoDeObra> GetMaoDeObra(string descricao = null, int idMaoDeObra = 0)
        {
            List<MaoDeObra> lstMaoDeObra = new List<MaoDeObra>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var urlPreenchida = ApiBaseUrl + "MaoDeObra/GetMaoDeObra?idMaoDeObra=" + idMaoDeObra;

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlPreenchida);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.MaoDeObra>>(streamReader.ReadToEnd()).ToList();
                lstMaoDeObra = retornoAPI;
            }

            //Fecha a requisição existente
            if (httpResponse != null)
            {
                httpResponse.Dispose();
                httpResponse.Close();
            }

            //Retorna do valor
            return lstMaoDeObra;
        }

        public bool DeleteMaoDeObra(string descricao = "", int idMaoDeObra = 0)
        {
            try
            {
                //Recupera o endereço do serviço e monta a requisição. 
                string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
                string vPath = "MaoDeObra/DeleteMaoDeObra?descricao=" + descricao +
                               "&idMaoDeObra=" + idMaoDeObra;

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
        /// <param name="maoDeObra"></param>
        /// <returns></returns>
        public bool PostMaoDeObra(MaoDeObra maoDeObra)
        {
            MaoDeObra objMaoDeObra = new MaoDeObra();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "MaoDeObra/PostMaoDeObra?" +
                                "idMaoDeObra=" + maoDeObra.IdMaoDeObra +
                                "&descricao=" + maoDeObra.Descricao +
                                "&valor=" + maoDeObra.Valor.ToString();
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
        /// <param name="maoDeObra"></param>
        /// <returns></returns>
        public bool PutMaoDeObra(MaoDeObra maoDeObra)
        {
            MaoDeObra objMaoDeObra = new MaoDeObra();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "MaoDeObra/PutMaoDeObra?" +
                                "&descricao=" + maoDeObra.Descricao +
                                "&valor=" + maoDeObra.Valor.ToString();
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

    public class GRIDMaoDeObra
    {
        public int IdMaoDeObra { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
    }
}
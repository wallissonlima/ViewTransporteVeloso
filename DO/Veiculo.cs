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
    public class Veiculo
    {
        public int IdVeiculo { get; set; }
        public int IdTipoVeiculo { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public string Chassi { get; set; }
        public string Descricao { get; set; }
        public bool ZeroQuilometro { get; set; }


        #region [REQUISIÇÕES HTTPS]
        public List<Veiculo> GetAll()
        {
            List<Veiculo> lstVeiculo = new List<Veiculo>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var vPath = "Veiculo/GetAll";

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + vPath);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.Veiculo>>(streamReader.ReadToEnd()).ToList();
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

        public List<Veiculo> GetVeiculo(string placa = null, int idVeiculo = 0)
        {
            List<Veiculo> lstVeiculo = new List<Veiculo>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var vPath = "Veiculo/GetVeiculo?placa=" + placa +
                        "&idVeiculo=" + idVeiculo;

            //Preenche o cabeçalho da requisição
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + vPath);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            //Efetua uma requisição do tipo JSON
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Obtem a resposta e desserializa o objeto Json.
                var retornoAPI = JsonConvert.DeserializeObject<List<DO.Veiculo>>(streamReader.ReadToEnd()).ToList();
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

        public bool DeleteVeiculo(string placa = "", int idVeiculo = 0)
        {
            try
            {
                //Recupera o endereço do serviço e monta a requisição. 
                string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
                string vPath = "Veiculo/DeleteVeiculo?placa=" + placa +
                               "&idVeiculo=" + idVeiculo;

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
        /// <param name="veiculo"></param>
        /// <returns></returns>
        public bool PostVeiculo(Veiculo veiculo)
        {
            Veiculo objVeiculo = new Veiculo();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "Veiculo/PostVeiculo?" + 
                                "idVeiculo=" + veiculo.IdVeiculo +
                                "&idTipoVeiculo=" + veiculo.IdTipoVeiculo +
                                "&placa=" + veiculo.Placa +
                                "&renavam=" + veiculo.Renavam +
                                "&chassi=" + veiculo.Chassi +
                                "&descricao=" + veiculo.Descricao +
                                "&zeroQuilometro=" + veiculo.ZeroQuilometro;
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
        /// <param name="veiculo"></param>
        /// <returns></returns>
        public bool PutVeiculo(Veiculo veiculo)
        {
            Veiculo objVeiculo = new Veiculo();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            string PerfilPath = "Veiculo/PutVeiculo?" +
                                "idTipoVeiculo=" + veiculo.IdTipoVeiculo +
                                "&placa=" + veiculo.Placa +
                                "&renavam=" + veiculo.Renavam +
                                "&chassi=" + veiculo.Chassi +
                                "&descricao=" + veiculo.Descricao +
                                "&zeroQuilometro=" + veiculo.ZeroQuilometro;
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

    public class GRIDVeiculo
    {
        public int IdVeiculo { get; set; }
        public string DescricaoTipoVeiculo { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public string Chassi { get; set; }
        public string Descricao { get; set; }
        public bool ZeroQuilometro { get; set; }
    }
}
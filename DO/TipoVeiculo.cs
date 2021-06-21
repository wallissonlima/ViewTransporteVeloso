using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;

namespace ViewTransporteVeloso.DO
{
    public class TipoVeiculo
    {
        public int IdTipoVeiculo { get; set; }
        public string Descricao { get; set; }


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

        public List<TipoVeiculo> GetTipoVeiculo(int idTipoVeiculo)
        {
            List<TipoVeiculo> lstTipoVeiculo = new List<TipoVeiculo>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var urlPreenchida = ApiBaseUrl + "TipoVeiculo/GetTipoVeiculo?idTipoVeiculo=" + idTipoVeiculo;

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
    }
}
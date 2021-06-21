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
    public class MaoDeObra
    {
        public int IdMaoDeObra { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }

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

        public List<MaoDeObra> GetMaoDeObra(object p, int idMaoDeObra)
        {
            List<MaoDeObra> lstMaoDeObra = new List<MaoDeObra>();

            //Recupera o endereço do serviço e monta a requisição. 
            string ApiBaseUrl = WebConfigurationManager.AppSettings["servicoTransporteVeloso"];
            var urlPreenchida = ApiBaseUrl + "TipoVeiculo/GetTipoVeiculo?idTipoVeiculo=" + idMaoDeObra;

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
    }
}
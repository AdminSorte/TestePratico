using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TestePratico.Web.Services
{
    public class APIService
    {
        System.Net.Http.HttpClient client = new HttpClient();

        public async Task<List<Models.Agenda>> GetAgendasAsync()
        {
            try
            {
                string url = "http://localhost:8084/api/agenda/"; // url hospedada no IIS local, porta 8084
                var response = await client.GetStringAsync(url);

                var format = "dd/MM/yyyy HH:mm:ss"; 
                var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };

                var agendas = JsonConvert.DeserializeObject<List<Models.Agenda>>(response, dateTimeConverter);
                return agendas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddAgendaAsync(Models.Agenda agenda)
        {
            try
            {
                string url = "http://localhost:8084/api/agenda/{0}"; // url hospedada no IIS local, porta 8084
                var uri = new Uri(string.Format(url, agenda.ID));
                var data = JsonConvert.SerializeObject(agenda);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir agenda.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateAgendaAsync(Models.Agenda agenda)
        {
            string url = "http://localhost:8084/api/agenda/{0}"; // url hospedada no IIS local, porta 8084
            var uri = new Uri(string.Format(url, agenda.ID));
            var data = JsonConvert.SerializeObject(agenda);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar agenda.");
            }
        }

        public async Task DeletaAgendaAsync(int id)
        {
            string url = "http://localhost:8084/api/agenda/{0}"; // url hospedada no IIS local, porta 8084
            var uri = new Uri(string.Format(url, id));
            await client.DeleteAsync(uri);
        }
    }
}
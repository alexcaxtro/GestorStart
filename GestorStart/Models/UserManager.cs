using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestorStart.Models
{
    class UserManager
    {
        const String URL = "https://www.doctoralanza.cl/listado_pac.php";
        const String LoginWebServiceUrl = "https://www.doctoralanza.cl/login_mov.php";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Conncetion", "close");

            return client;
        }

        public async Task<IEnumerable<Paciente>> getPacientes()
        {
            HttpClient client = GetClient();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Paciente>>(content);
            }

            return Enumerable.Empty<Paciente>();
        }

        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient(); 
            var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "/" + "password=" + password);
            return response.IsSuccessStatusCode; // return either true or false
        }

    }
}

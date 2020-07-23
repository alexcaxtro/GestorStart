using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using GestorStart.Models;
using Newtonsoft.Json;
using System.Linq;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace GestorStart.RestApiClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "https://www.doctoralanza.cl/login_mov.php";
        private const string infoPacUrl = "https://www.doctoralanza.cl/info_pac.php/";
        private const string infoCalUrl = "https://www.doctoralanza.cl/cal_pac.php/";
        private const string MainWebServiceUrl_new = "https://www.doctoralanza.cl/newlogin.php";
        private Response usuario = new Response();
        string infoUsuario { get; set; }

        public async Task<bool> checkLogin(string username, string password)
        {
           
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(MainWebServiceUrl_new + "?" + "username=" + username + "&" + "password=" + password);
                string infoUsuario = await response.Content.ReadAsStringAsync();
                usuario = JsonConvert.DeserializeObject<Response>(infoUsuario);
                

            if (response.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                
                if (jsonstring.Contains("successfull"))
                {
                    var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                    return response.IsSuccessStatusCode;
                    
                } 
                    return false;
                }
            return false;
        }

        public async Task<string> getId(string username, string password)
        {

            HttpClient client = new HttpClient();
           var response = await client.GetAsync(MainWebServiceUrl_new + "?" + "username=" + username + "&" + "password=" + password);
            //string infoUsuario = await response.Content.ReadAsStringAsync();
            //usuario = JsonConvert.DeserializeObject<Response>(infoUsuario);
            // string userId = usuario.userid.ToString();
            var reg = "";
            return (reg); 
        }


        public async Task<IEnumerable<Paciente>> getPaciente()
        {
            HttpClient client = new HttpClient();
            string idUsuario = usuario.userid;           
            var res = await client.GetAsync(infoPacUrl + "?" + "UsuarioId=" + 1);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Paciente>>(content);
            }

            return Enumerable.Empty<Paciente>();
        }

        public async Task<IEnumerable<Calendario>> getCitas()
        {
            HttpClient client = new HttpClient();
            
            string idUsuario = usuario.userid;
            var res = await client.GetAsync(infoCalUrl + "?" + "UsuarioId=" + 1);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Calendario>>(content);
            }

            return Enumerable.Empty<Calendario>();
        }

        
    }
}

using GestorStart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GestorStart.RestApiClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "https://www.doctoralanza.cl/login_mov.php";
        private const string infoPacUrl = "https://www.doctoralanza.cl/info_pac.php/";
        private const string infoCalUrl = "https://www.doctoralanza.cl/cal_pac.php/";
        private const string MainWebServiceUrl_new = "https://www.doctoralanza.cl/newlogin.php";
        private Response usuario = new Response();
        



        //Método que realiza el login boolean que solo entrega un true o false pero no entrega más párametro, realiza el login sin problemas
        public async Task<bool> checkLogin(string username, string password)
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(MainWebServiceUrl_new + "?" + "username=" + username + "&" + "password=" + password);
            string infoUsuario = await response.Content.ReadAsStringAsync();
            usuario = JsonConvert.DeserializeObject<Response>(infoUsuario);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonstring = await response.Content.ReadAsStringAsync();

                if (!jsonstring.Contains("{\"UsuarioId\":0,\"username\":0}"))
                {
                    var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                    return response.IsSuccessStatusCode;

                }
                return false;
            }
            return false;
        }
        //Método que realiza lo mismo que login anterior pero en esta oportunidad para guardar el id del usuario logeado
        public async Task<string> getId(string username, string password)
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(MainWebServiceUrl_new + "?" + "username=" + username + "&" + "password=" + password);
            string infoUsuario = await response.Content.ReadAsStringAsync();
            var usuario = JsonConvert.DeserializeObject<Usuario>(infoUsuario);
            string usrId = usuario.UsuarioId.ToString();
            return (usrId);
        }
        //Necesito guardar este usrId para usarlo en los métodos que estan abajo de último
        public async Task<Paciente> getPaciente()
        {
            if (Application.Current.Properties.ContainsKey("id"))
            {
                var id = Application.Current.Properties["id"] as string;
                int UsuarioId = Convert.ToInt32(id);
                HttpClient client = new HttpClient();
                
                var res = await client.GetAsync(infoPacUrl + "?" + "UsuarioId=" + UsuarioId);

                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Paciente>(content);
                }
            }
            
            return null;
        }

        public async Task<Paciente> tenerPaciente()
        {


            if (Application.Current.Properties.ContainsKey("id"))
            {
                var id = Application.Current.Properties["id"] as string;
                int UsuarioId = Convert.ToInt32(id);

                HttpClient client = new HttpClient();
                string idUsuario = usuario.userid;
                var res = await client.GetAsync(infoPacUrl + "?" + "UsuarioId=" + UsuarioId);
                
                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    Paciente px = JsonConvert.DeserializeObject<Paciente>(content);
                    return px;
                }
                return null;
            }
            return null;
        }

        

        public async Task<IEnumerable<Calendario>> getCitas()
        {
            if (Application.Current.Properties.ContainsKey("id"))
            {
                var id = Application.Current.Properties["id"] as string;
                int UsuarioId = Convert.ToInt32(id);
                HttpClient client = new HttpClient();

                string idUsuario = usuario.userid;
                var res = await client.GetAsync(infoCalUrl + "?" + "UsuarioId=" + UsuarioId);

                if (res.IsSuccessStatusCode)
                {
                    string content = await res.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Calendario>>(content);
                }

            }
            return Enumerable.Empty<Calendario>();
        }
    }
}

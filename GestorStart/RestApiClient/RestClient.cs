using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GestorStart.Models;

namespace GestorStart.RestApiClient
{
    public class RestClient<T>
    {
        private const string MainWebServiceUrl = "https://www.doctoralanza.cl/login_mov.php"; 
     
        //public async Task<bool> checkLogin(string username, string password)
        //{
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetAsync(MainWebServiceUrl + "username=" + username + "/" + "password=" + password);
        //    return response.IsSuccessStatusCode; // return either true or false
        //}

        public async Task<bool> checkLogin(string username, string password)
        {
           
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(MainWebServiceUrl + "?" + "username=" + username + "&" + "password=" + password);

                if (response.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                
                if (jsonstring.Contains("exitoso"))
                {
                   
                    var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonstring);
                    return response.IsSuccessStatusCode;
                }
                  
                    
                    return false;
                }

            return false;
        }
     
    }
}

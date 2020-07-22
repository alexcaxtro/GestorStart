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
       
        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(MainWebServiceUrl +"?"+ "username=" + username + "&" + "password=" + password);
            var result= response.Content.ReadAsStringAsync();
            if (!result.Result.Equals(1))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

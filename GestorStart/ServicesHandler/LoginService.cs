using GestorStart.Models;
using GestorStart.RestApiClient;
using System.Threading.Tasks;

namespace GestorStart.ServicesHandler
{
    public class LoginService
    {
        RestClient<UserDetailCredentials> _restClient = new RestClient<UserDetailCredentials>();
        RestClient<Response> _res = new RestClient<Response>();
        //Función Booleana con los párametros username y password origen view del login y destino RestApiClient 

        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.checkLogin(username, password);

            return check;
        }

        public async Task<string> getDatos(string username, string password)
        {
            var check1 = await _res.getId(username, password);
            return check1;
        }
    }
}




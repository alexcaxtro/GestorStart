using GestorStart.Models;
using GestorStart.RestApiClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestorStart.ServicesHandler
{
    public class LoginService
    {
        RestClient<UserDetailCredentials> _restClient = new RestClient<UserDetailCredentials>();

        // Boolean function with the following parameters of username & password.
        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.checkLogin(username, password);

            return check;
        }

    }
}
    



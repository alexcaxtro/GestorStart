using GestorStart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestorStart.Services
{
    public class ApiServices
    {
      
        public async Task<Respuesta> GetListAsync<T>(string urlBase)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(urlBase);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Respuesta
                    {
                        IsSuccess = false,
                        Message = result,

                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Respuesta
                {
                    IsSuccess = true,
                    Result = list
                };

            }
            catch (Exception ex)
            {
                return new Respuesta
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}

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
        //    public async Task<Response> GetListAsync<T> (string urlBase)
        //    {
        //        try
        //        {
        //            var client = new HttpClient();
        //            var response = await client.GetAsync(urlBase);
        //            var result = await response.Content.ReadAsStringAsync();

        //            if (!response.IsSuccessStatusCode)
        //            {
        //                return new Response
        //                {
        //                    IsSucces = false,
        //                    Message = result,

        //                };
        //            }

        //            var list = JsonConvert.DeserializeObject<List<T>>(result);
        //            return new Response
        //            {
        //                IsSucces = true,
        //                Result = list
        //            };

        //        }
        //        catch (Exception ex)
        //        {
        //            return new Response
        //            {
        //                IsSucces= false,
        //                Message = ex.Message
        //            };
        //        }
        //    }
        //}
    }
}

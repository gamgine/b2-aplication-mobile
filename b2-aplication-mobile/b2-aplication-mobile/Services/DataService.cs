using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace b2_aplication_mobile.Services
{
    class DataService
    {
        public static async Task<dynamic> getDataFromService(string queryStyring)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryStyring);
            if( response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                dynamic data = JsonConvert.DeserializeObject(json);
                return data;
            }
            return null;
        }
    }
}

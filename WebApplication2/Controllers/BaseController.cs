using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class BaseController : Controller
    {
        public async Task<T> GetWSObject<T>(string uriActionString)
        {
            T returnValue =
                default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(@"https://www.receitaws.com.br/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(uriActionString);
                    response.EnsureSuccessStatusCode();
                    returnValue = JsonConvert.DeserializeObject<T>(((HttpResponseMessage)response).Content.ReadAsStringAsync().Result);
                }
                return returnValue;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
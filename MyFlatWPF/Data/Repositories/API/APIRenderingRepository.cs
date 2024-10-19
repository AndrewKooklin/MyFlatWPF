using MyFlatWPF.Data.Repositories.Abstract;
using MyFlatWPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.Data.Repositories.API
{
    public class APIRenderingRepository : IRenderingRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response;
        string apiResponse = "";
        string result;
        bool apiResponseConvert;

        public List<TopMenuLinkNameModel> GetTopMenuLinkNames()
        {
            List<TopMenuLinkNameModel> tmln = new List<TopMenuLinkNameModel>();

            urlRequest = $"{url}" + "HomePageEditAPI/GetTopMenuLinkNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                tmln = JsonConvert.DeserializeObject<List<TopMenuLinkNameModel>>(result);
            }

            return tmln;
        }
    }
}

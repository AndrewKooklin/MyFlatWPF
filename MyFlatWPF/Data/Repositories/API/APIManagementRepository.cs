using MyFlatWPF.Model;
using MyFlatWPF.Model.ManagementModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyFlatWPF.Data.Repositories.API
{
    class APIManagementRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response;
        string apiResponse = "";
        string result;
        bool apiResponseConvert;

        public List<ServiceOrdersCountModel> GetServiceOrdersCount()
        {
            List<ServiceOrdersCountModel> serviceOrdersCount = new List<ServiceOrdersCountModel>();
            urlRequest = $"{url}" + "ServicesAPI/GetServiceOrdersCount";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                serviceOrdersCount = JsonConvert.DeserializeObject<List<ServiceOrdersCountModel>>(result);
            }

            return serviceOrdersCount;
        }

        public List<OrderModel> GetOrdersByService(string serviceName)
        {
            List<OrderModel> orders = new List<OrderModel>();
            urlRequest = $"{url}" + "OrdersAPI/GetOrdersByService/" + $"{serviceName}";

            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string json = _httpClient.GetStringAsync(urlRequest).Result;
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(json);
            }

            return orders;
        }

        public List<string> GetStatusNames()
        {
            List<string> names = new List<string>();
            urlRequest = $"{url}" + "StatusesAPI/GetStatusNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                names = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return names;
        }

        public async Task<bool> ChangeStatusOrder(ChangeStatusModel model)
        {
            urlRequest = $"{url}" + "StatusesAPI/ChangeStatusOrder/" + $"{model}";

            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await _httpClient.PostAsJsonAsync(urlRequest, model);
            }

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();
            urlRequest = $"{url}" + "OrdersAPI/GetAllOrders";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                orders = JsonConvert.DeserializeObject<List<OrderModel>>(result);
            }

            return orders;
        }

        public async Task<List<OrderModel>> GetOrdersByPeriod(PeriodModel model)
        {
            List<OrderModel> orders = new List<OrderModel>();
            urlRequest = $"{url}" + "OrdersAPI/GetOrdersByPeriod/" + $"{model}";

            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (String.IsNullOrEmpty(apiResponse))
                    {
                        return null;
                    }
                    orders = JsonConvert.DeserializeObject<List<OrderModel>>(apiResponse);
                }
            }

            return orders;
        }

        public List<TopMenuLinkNameModel> GetTopLinks()
        {
            List<TopMenuLinkNameModel> topLinks = new List<TopMenuLinkNameModel>();

            urlRequest = $"{url}" + "HomePageEditAPI/GetTopMenuLinkNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                topLinks = JsonConvert.DeserializeObject<List<TopMenuLinkNameModel>>(result);
            }

            return topLinks;
        }

        public async Task<bool> ChangeNameLinkTopMenu(TopMenuLinkNameModel model)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/ChangeNameLinkTopMenu/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
        }

        public List<RandomPhraseModel> GetRandomPhrasesFromDB()
        {
            List<RandomPhraseModel> phrases = new List<RandomPhraseModel>();

            urlRequest = $"{url}" + "ProjectsPageEditAPI/GetRandomPhrases";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                phrases = JsonConvert.DeserializeObject<List<RandomPhraseModel>>(result);
            }

            return phrases;
        }

        public async Task<bool> ChangeMainImage(HomePagePlaceholderModel model)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/ChangeMainImage/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
        }
    }
}

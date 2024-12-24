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

            urlRequest = $"{url}" + "HomePageEditAPI/GetRandomPhrases";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                phrases = JsonConvert.DeserializeObject<List<RandomPhraseModel>>(result);
            }

            return phrases;
        }

        public async Task<bool> AddRandomPhrase(RandomPhraseModel model)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/AddRandomPhrase/" + $"{model}";
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

        public async Task<bool> ChangeRandomPhrase(RandomPhraseModel model)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/ChangeRandomPhrase/" + $"{model}";
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

        public async Task<bool> DeleteRandomPhrase(int id)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/DeleteRandomPhrase/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
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

        public async Task<bool> ChangeLeftCentralAreaText(HomePagePlaceholderModel model)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/ChangeLeftCentralAreaText/" + $"{model}";
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

        public async Task<bool> ChangeBottomAreaHeader(HomePagePlaceholderModel model)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/ChangeBottomAreaHeader/" + $"{model}";
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

        public async Task<bool> ChangeBottomAreaContent(HomePagePlaceholderModel model)
        {
            urlRequest = $"{url}" + "HomePageEditAPI/ChangeBottomAreaContent/" + $"{model}";
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

        public List<ProjectModel> GetProjectsFromDB()
        {
            List<ProjectModel> projects = new List<ProjectModel>();

            urlRequest = $"{url}" + "ProjectsPageEditAPI/GetProjectsFromDB";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                projects = JsonConvert.DeserializeObject<List<ProjectModel>>(result);
            }

            return projects;
        }

        public ProjectModel GetProjectById(int id)
        {
            ProjectModel project = new ProjectModel();

            urlRequest = $"{url}" + "ProjectsPageEditAPI/GetProjectById/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                project = JsonConvert.DeserializeObject<ProjectModel>(result);
            }

            return project;
        }

        public async Task<bool> ChangeProject(ProjectModel model)
        {
            urlRequest = $"{url}" + "ProjectsPageEditAPI/ChangeProject/" + $"{model}";
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

        public async Task<bool> AddProjectToDB(ProjectModel model)
        {
            urlRequest = $"{url}" + "ProjectsPageEditAPI/AddProjectToDB/" + $"{model}";
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

        public async Task<bool> DeleteProjectById(int id)
        {
            urlRequest = $"{url}" + "ProjectsPageEditAPI/DeleteProjectById/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
        }

        public ServiceModel GetServiceById(int id)
        {
            ServiceModel service = new ServiceModel();

            urlRequest = $"{url}" + "ServicesPageEditAPI/GetServiceById/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                service = JsonConvert.DeserializeObject<ServiceModel>(result);
            }

            return service;
        }

        public async Task<bool> ChangeService(ServiceModel model)
        {
            urlRequest = $"{url}" + "ServicesPageEditAPI/ChangeService/" + $"{model}";
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

        public async Task<bool> AddServiceToDB(ServiceModel model)
        {
            urlRequest = $"{url}" + "ServicesPageEditAPI/AddServiceToDB/" + $"{model}";
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

        public async Task<bool> DeleteServiceById(int id)
        {
            urlRequest = $"{url}" + "ServicesPageEditAPI/DeleteServiceById/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
        }

        public PostModel GetPostById(int id)
        {
            PostModel post = new PostModel();

            urlRequest = $"{url}" + "BlogPageEditAPI/GetPostById/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                post = JsonConvert.DeserializeObject<PostModel>(result);
            }

            return post;
        }

        public async Task<bool> AddPostToDB(PostModel model)
        {
            urlRequest = $"{url}" + "BlogPageEditAPI/AddPostToDB/" + $"{model}";
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

        public async Task<bool> ChangePost(PostModel model)
        {
            urlRequest = $"{url}" + "BlogPageEditAPI/ChangePost/" + $"{model}";
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

        public async Task<bool> DeletePostById(int id)
        {
            urlRequest = $"{url}" + "BlogPageEditAPI/DeletePostById/" + $"{id}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, id))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }

            return apiResponseConvert;
        }
    }
}

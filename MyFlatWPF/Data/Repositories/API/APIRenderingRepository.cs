using MyFlatWPF.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyFlatWPF.Data.Repositories.API
{
    public class APIRenderingRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response;
        string apiResponse = "";
        bool apiResponseConvert;

        public async Task<bool> SaveOrder(OrderModel order)
        {
            urlRequest = $"{url}" + "OrdersAPI/SaveOrder/" + $"{order}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, order))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponseConvert = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            return apiResponseConvert;
        }

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

        public List<string> GetRandomPhraseNames()
        {
            List<string> lrp = new List<string>();

            urlRequest = $"{url}" + "HomePageEditAPI/GetRandomPhraseNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                lrp = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return lrp;
        }

        public HomePagePlaceholderModel GetHomePagePlaceholder()
        {
            HomePagePlaceholderModel phm = new HomePagePlaceholderModel();

            urlRequest = $"{url}" + "HomePageEditAPI/GetHomePagePlaceholder";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                phm = JsonConvert.DeserializeObject<HomePagePlaceholderModel>(result);
            }

            return phm;
        }

        public List<string> GetServiceNames()
        {
            List<string> names = new List<string>();
            urlRequest = $"{url}" + "ServicesAPI/GetServiceNames";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                names = JsonConvert.DeserializeObject<List<string>>(result);
            }

            return names;
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

        public List<ServiceModel> GetServicesFromDB()
        {
            List<ServiceModel> services = new List<ServiceModel>();

            urlRequest = $"{url}" + "ServicesPageEditAPI/GetServicesFromDB";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                services = JsonConvert.DeserializeObject<List<ServiceModel>>(result);
            }

            return services;
        }

        public List<PostModel> GetPostsFromDB()
        {
            List<PostModel> posts = new List<PostModel>();

            urlRequest = $"{url}" + "BlogPageEditAPI/GetPostsFromDB";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                posts = JsonConvert.DeserializeObject<List<PostModel>>(result);
            }

            return posts;
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

        public ContactModel GetContactsFromDB()
        {
            ContactModel contacts = new ContactModel();

            urlRequest = $"{url}" + "ContactsPageEditAPI/GetContactsFromDB";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                contacts = JsonConvert.DeserializeObject<ContactModel>(result);
            }

            return contacts;
        }

        public List<SocialModel> GetSocialLinksFromDB()
        {
            List<SocialModel> social = new List<SocialModel>();

            urlRequest = $"{url}" + "ContactsPageEditAPI/GetSocialLinksFromDB";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                social = JsonConvert.DeserializeObject<List<SocialModel>>(result);
            }

            return social;
        }
    }
}

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
    public class APIRenderingRepository/* : IRenderingRepository*/
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
    }
}

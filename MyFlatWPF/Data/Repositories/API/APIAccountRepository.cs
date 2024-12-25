using Microsoft.AspNet.Identity.EntityFramework;
using MyFlatWPF.Model;
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
    public class APIAccountRepository
    {
        private HttpClient _httpClient;
        private string url = @"https://localhost:44388/";
        string urlRequest = "";
        HttpResponseMessage response;
        string apiResponse = "";
        string result;
        bool apiResponseConvert;
        private List<string> userRoles = new List<string>();
        private List<string> roleNames;
        private IEnumerable<IdentityRole> roles;
        private List<IdentityUser> users;
        private UserWithRolesModel userWithRoles;

        public List<IdentityUser> GetUsers()
        {
            urlRequest = $"{url}" + "UsersAPI/GetUsers";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string result = _httpClient.GetStringAsync(urlRequest).Result;
                users = JsonConvert.DeserializeObject<List<IdentityUser>>(result);
            }

            return users;
        }

        public async Task<bool> CheckUserToDB(LoginModel model)
        {
            urlRequest = $"{url}" + "LoginAPI/CheckUserToDB/" + $"{model}";
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

        public async Task<List<string>> GetUserRoles(LoginModel model)
        {
            urlRequest = $"{url}" + "LoginAPI/GetUserRoles/" + $"{model}";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (response = await _httpClient.PostAsJsonAsync(urlRequest, model))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    userRoles = JsonConvert.DeserializeObject<List<string>>(apiResponse);
                }
            }

            return userRoles;
        }

        public async Task<bool> CreateUser(RegisterModel model)
        {
            urlRequest = $"{url}" + "RegisterAPI/CreateUser/" + $"{model}";
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

        public async void LogoutUser()
        {
            urlRequest = $"{url}" + "LogoutAPI/LogoutUser";
            using (_httpClient = new HttpClient())
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                await _httpClient.GetAsync(urlRequest);
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UserApiModels;

namespace UserApiClient
{
    public class ApiClient
    {
        public async Task Create(User user)
        {
            var myContent = JsonConvert.SerializeObject(user);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44337");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/users");
            request.Content = new StringContent(myContent, Encoding.UTF8, "application/json");

            var m = await client.SendAsync(request);
        }
        public string GetToken()
        {
            var admin = new Admin
            {
                Login = "admin@gmail.com",
                Password = "123456"
            };

            string myContent = JsonConvert.SerializeObject(admin);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44337");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/account");
            request.Content = new StringContent(myContent, Encoding.UTF8, "application/json");

            var responseMessage = client.SendAsync(request).Result;

            string token = responseMessage.Content.ReadAsStringAsync().Result;

            var ob = JsonConvert.DeserializeObject<TokenResponse>(token);
            return ob.access_token;
        }
        public async Task<User> GetDetails(string iin)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44337");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            var request = new HttpRequestMessage(HttpMethod.Get, "/api/users?iin=" + iin);

            var response = await httpClient.SendAsync(request);
            string stringResult = await response.Content.ReadAsStringAsync();

            User user = JsonConvert.DeserializeObject<User>(stringResult);

            return user;
        }
        public async Task Update(User user)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://localhost:44337");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            var request = new HttpRequestMessage(HttpMethod.Put, "/api/users");
            request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(request);
        }

        public async Task Delete(string iin)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44337");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());

            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/users?iin=" + iin);

            var response = await httpClient.SendAsync(request);
        }
    }
    class TokenResponse
    {
        public string access_token { get; set; }
    }


}
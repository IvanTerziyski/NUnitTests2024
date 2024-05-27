using Newtonsoft.Json;
using System.Text;
using TestProject1.Core.Models;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllUsers()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer ff0cff9050bfee5de9386da126e3f76128cfe323d049505c46612fa55f8c8a66");
            var response = await httpClient.GetAsync("https://gorest.co.in/public/v2/users/");
            Assert.AreEqual("OK", response.StatusCode.ToString());


            var jsonContent = response.Content.ReadAsStringAsync().Result;
            var responseBody = JsonConvert.DeserializeObject<List<UserResponse>>(jsonContent);

            
        }
        [Test]
        public async Task CreateUser()
        {
            var httpClient = new HttpClient();

            var user = new UserRequest
            {
                Name = "test",
                Email = "test@test.com",
                Gender = "male",
                Status = "active"
            };
            var requestContent = JsonConvert.SerializeObject(user);
            var requestBody = new StringContent(requestContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://gorest.co.in/public/v2/users/", requestBody);
            Assert.AreEqual("Created", response.StatusCode.ToString());
        }
    }
}
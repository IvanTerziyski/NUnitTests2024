using Newtonsoft.Json;
using TestProject1.Core.Models;
using TestProject1.Core.Utils;
using System.Text;
using System.Xml.Linq;

namespace NUnitTestProject.Tests
{
    [TestFixture]
    public class BaseTest
    {
        private HttpClientHelper _handler;
        [SetUp]
        public void Setup()
        {
            _handler = new HttpClientHelper();
        }

        [Test]
        public async Task GetAllUser()
        {
            var responseFromHelper = _handler.GET("users");
        }
        [Test]
        public async Task CreateUser()
        {
            var userName = new Guid().ToString();
            var requestBody = _handler.CreateUserRequestBody(userName);
            var response = await _handler.POST("users", requestBody);
            Assert.AreEqual("Created", response.StatusCode.ToString());
            //Asserts
            //id =/= empty or 0
            //name should be equal
        }
        [Test]
        public async Task GetSpecificUser()
        {
            var userName = new Guid().ToString();
            var requestBody = _handler.CreateUserRequestBody(userName);
            var request = await _handler.POST("users", requestBody);
            var responseBody = request.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserResponse>(responseBody.Result);
        }

        [Test]
        public async Task UpdateUser()
        {
            //POST - to create a new user
            // HttpClientHelper.CreateUserRequestBody()
            // PUT - users/{user.ID}
            //Assert the response
        }

        [Test]
        public async Task DeleteUser()
        {
            //POST - to create a new user


            //DELETE - users/{user.ID}


            //Assert the response


        }
    }
}

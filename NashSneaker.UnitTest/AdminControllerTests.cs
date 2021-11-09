using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using NashSneaker.ViewModel;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using NashSneaker.Data;

namespace NashSneaker.UnitTest
{
    public class AdminControllerTests
    {
        private string jwtToken;
        public class AdminAuthorized
        {
            public string message { get; set; }
            public string fullName { get; set; }
            public string jwt { get; set; }
        }

        [Fact]
        public async Task Login_WithAdminAccount_ReturnStatusCodeOkAndJwtToken()
        {
            // Arrange
            var httpClient = new HttpClient();

            var loginVM = new LoginUserViewModel
            {
                Email = "classic.nct@gmail.com",
                Password = "I_amThanh2001",
                RememberMe = false
            };

            // Act
            var response = await httpClient.PostAsJsonAsync("https://localhost:44348/api/Admin/Login", loginVM);
            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<AdminAuthorized>(json);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("Welcome Admin!", data.message);
            jwtToken = data.jwt;
        }

        [Fact]
        public async Task Categories_WithJwtToken_ReturnStatusCodeOk()
        {
            await Login_WithAdminAccount_ReturnStatusCodeOkAndJwtToken();

            // Arrange
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            // Act
            var response = await httpClient.GetAsync("https://localhost:44348/api/Admin/Categories");
            var json = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task AddNewCategory_WithJwtTokenAndNewCategory_ReturnStatusCodeOk()
        {
            await Login_WithAdminAccount_ReturnStatusCodeOkAndJwtToken();

            // Arrange
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var category = new Category
            {
                Name = "test",
                Description = "test description"
            };

            // Act
            var response = await httpClient.PostAsJsonAsync("https://localhost:44348/api/Admin/AddNewCategory", category);
            var json = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task EditCategory_WithJwtTokenAndCategory_ReturnStatusCodeOk()
        {
            await Login_WithAdminAccount_ReturnStatusCodeOkAndJwtToken();

            // Arrange
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var category = new Category
            {
                Id = 43,
                Name = "test 02",
                Description = "test description 02"
            };

            // Act
            var response = await httpClient.PutAsJsonAsync("https://localhost:44348/api/Admin/EditCategory", category);
            var json = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteCategory_WithJwtTokenAndCategoryId_ReturnStatusCodeOk()
        {
            await Login_WithAdminAccount_ReturnStatusCodeOkAndJwtToken();

            // Arrange
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            // Act
            var response = await httpClient.DeleteAsync("https://localhost:44348/api/Admin/DeleteCategory/43");
            var json = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

using dotnet_core_xunit.Controllers;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit_test.Fixture;
using dotnet_core_xunit_test.Theory;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace dotnet_core_xunit_test
{
    // OneTimeSetup 
    /** https://xunit.net/docs/shared-context */
    public class UserControllerTest : IClassFixture<ControllerFixture>
    {
        UserController userController;

        /**
         * xUnit constructor runs before each test. 
         */
        public UserControllerTest(ControllerFixture fixture)
        {
             userController = fixture.userController;
        }

        [Fact]
        public void Get_WithoutParam_Ok_Test()
        {
            var result = userController.Get() as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as string[]).Length == 2);
        }

        [Theory]
        [InlineData(0)]
        public void GetUser_WithNonUser_ThenBadRequest_Test(int id)
        {
            var result = userController.GetUser(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("User not found!", result.Value);
        }

        [Theory]
        [InlineData(454673)]
        public void GetUser_WithTestData_ThenOk_Test(int id)
        {
            var result = userController.GetUser(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<UserDto.User>(result.Value);
        }

        [Theory]
        [ClassData(typeof(UserTheoryData))]
        public void AddUser_WithTestData_ThenOk_Test(UserDto.User userInfo)
        {
            var result = userController.AddUser(userInfo) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(userInfo), JsonConvert.SerializeObject(result.Value));
        }

        [Theory]
        [InlineData(0)]
        public void Delete_WithNonUser_ThenBadRequest_Test(int id)
        {
            var result = userController.Delete(id) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Failed to delete user!", result.Value);
        }

        [Theory]
        [InlineData(685349)]
        public void Delete_WithTestData_ThenOk_Test(int id)
        {
            var result = userController.Delete(id) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.IsType<UserDto.User>(result.Value);
        }
    }
}

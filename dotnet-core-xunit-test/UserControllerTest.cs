using AutoMapper;
using dotnet_core_xunit.Controllers;
using dotnet_core_xunit.Dtos;
using dotnet_core_xunit.Helpers;
using dotnet_core_xunit.Services;
using dotnet_core_xunit_test.Mock.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace dotnet_core_xunit_test
{
    public class UserControllerTest
    {
        TestDbContextMock testDbContextMock;
        UserService userService;
        IMapper mapper;

        UserController userController;

        public UserControllerTest()
        {
            /**
             * xUnit constructor runs before each test. 
             */
        
            // Mapper settings with original profiles.
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            mapper = mappingConfig.CreateMapper();

            testDbContextMock = new TestDbContextMock();

            // Create UserService with Memory Database
            userService = new UserService(testDbContextMock, mapper);

            userController = new UserController(userService);
        }

        [Fact]
        public void Get_Ok_Test()
        {
            var result = userController.Get() as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.True((result.Value as string[]).Length == 2);
        }

        [Fact]
        public void GetUser_NonUser_BadRequest_Test()
        {
            var result = userController.GetUser(0) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("User not found!", result.Value);
        }

        [Fact]
        public void GetUser_TestData_Ok_Test()
        {
            // mock data created by https://barisates.github.io/pretend
            UserDto.User mockUser = new UserDto.User()
            {
                CreateDate = DateTime.Now,
                Email = "nriyes",
                FullName = "jsx8td",
                Id = 298070,
                LastLogin = DateTime.Now,
                Password = "os0a3j",
                Status = 1,
            };

            userController.AddUser(mockUser);

            var result = userController.GetUser(298070) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(mockUser), JsonConvert.SerializeObject(result.Value));
        }

        [Fact]
        public void AddUser_TestData_Ok_Test()
        {
            // mock data created by https://barisates.github.io/pretend
            UserDto.User user = new UserDto.User()
            {
                Email = "yft97l",
                CreateDate = DateTime.Now,
                FullName = "8s0quo",
                Id = 210544,
                Password = "d87btl",
                LastLogin = DateTime.Now,
                Status = 1,
            };

            var result = userController.AddUser(user) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(result.Value));
        }

        [Fact]
        public void Delete_NonUser_BadRequest_Test()
        {
            var result = userController.Delete(0) as BadRequestObjectResult;

            Assert.Equal(400, result.StatusCode);
            Assert.Equal("Failed to delete user!", result.Value);
        }

        [Fact]
        public void Delete_TestData_Ok_Test()
        {
            // mock data created by https://barisates.github.io/pretend
            UserDto.User mockUser = new UserDto.User()
            {
                CreateDate = DateTime.Now,
                Email = "dj4j0i",
                FullName = "r0gugr",
                Id = 584653,
                LastLogin = DateTime.Now,
                Password = "a638nf",
                Status = 1,
            };

            userController.AddUser(mockUser);

            var result = userController.Delete(584653) as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonConvert.SerializeObject(mockUser), JsonConvert.SerializeObject(result.Value));
        }
    }
}

using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using UserManagementAPI.Controllers;
using UserManagementAPI.Data;
using UserManagementAPI.Models;
using AutoMapper;
using UserManagementAPI.Models.View;

namespace UserManagementAPI.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async void GetUsers_Returns_All_Users()
        {
            //Arrange
            var userContextMock = new Mock<UserManagementContext>();
            userContextMock.Setup<DbSet<User>>(x => x.Users)
                .ReturnsDbSet(TestDataHelper.GetFakeUserList());
            var _mapper = new Mock<IMapper>();

            //Act
            UsersController usersController = new UsersController(userContextMock.Object, (IMapper)_mapper);
            var users = (await usersController.GetUsers()).Value;

            //Assert
            Assert.NotNull(users);
            Assert.Equal(2, users.Count());
        }


        [Fact]
        public async void GetUser_Returns_A_User()
        {
            //Arrange
            var userContextMock = new Mock<UserManagementContext>();
            userContextMock.Setup<DbSet<User>>(x => x.Users)
                .ReturnsDbSet(TestDataHelper.GetFakeUserList());
            var _mapper = new Mock<IMapper>();

            //Act
            UsersController usersController = new UsersController(userContextMock.Object, (IMapper)_mapper);
            var user = (await usersController.GetUser(1)).Value;

            //Assert
            Assert.NotNull(user);
        }

        [Fact]
        public async void DeleteUser_Deletes_A_User()
        {
            //Arrange
            var userContextMock = new Mock<UserManagementContext>();
            userContextMock.Setup<DbSet<User>>(x => x.Users)
                .ReturnsDbSet(TestDataHelper.GetFakeUserList());
            var _mapper = new Mock<IMapper>();

            //Act
            UsersController usersController = new UsersController(userContextMock.Object, (IMapper)_mapper);
            await usersController.DeleteUser(1);
            var user = (await usersController.GetUser(1))

            //Assert
            Assert.Null(user);
        }
    }
    

    public class TestDataHelper
    {
        public static List<User> GetFakeUserList()
        {
            List<User> users = new List<User>();
            var user1 =
                new User("John","Doe","J.D@gmail.com","123-456-7890","Male", "USA",new DateTime(1930, 10, 1), "Admin");
            users.Add(user1);

            var user2 =
                new User("Mark", "Luther", "M.L@gmail.com","123-456-7890","USA","Male",new DateTime(1930, 10, 1),"Admin");
            users.Add(user2);
            return users;

            
        }
    }
}
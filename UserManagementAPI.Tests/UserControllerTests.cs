using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using UserManagementAPI.Controllers;
using UserManagementAPI.Data;
using UserManagementAPI.Models;

namespace UserManagementAPI.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async void GetUsers_Returns_The_Correct_Users()
        {
            ////Arrange
            //var userContextMock = new Mock<UserManagementContext>();
            //userContextMock.Setup<DbSet<User>>(x => x.Users)
            //    .ReturnsDbSet(TestDataHelper.GetFakeUserList());

            ////Act
            //UsersController usersController = new(userContextMock.Object);
            //var users = (await usersController.GetUsers()).Value;

            ////Assert
            //Assert.NotNull(users);
            //Assert.Equal(2, users.Count());
        }
    }
    

    public class TestDataHelper
    {
        internal static List<User> GetFakeUserList()
        {
            return new List<User>()
            {
                //new User
                //{
                //    Id = 1,
                //    FirstName = "John",
                //    LastName = "Doe",
                //    Email = "J.D@gmail.com",
                //    Phone = "123-456-7890",
                //    Nationality = "USA"
                //},
                //new User
                //{
                //    Id = 2,
                //    FirstName = "Mark",
                //    LastName = "Luther",
                //    Email = "M.L@gmail.com",
                //    Phone = "123-456-7890",
                //    Nationality = "USA"
                //}
            };
        }
    }
}
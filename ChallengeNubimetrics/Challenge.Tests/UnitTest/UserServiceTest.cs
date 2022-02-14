using Challenge.Core.Entities;
using Challenge.Core.Exceptions;
using Challenge.Tests.TestSupport;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Challenge.Tests
{
    public class UserServiceTest : TestBase
    {
        [Fact]
        public void Should_Give_Quantity_0()
        {
            //Arrange
            var BdName = Guid.NewGuid().ToString();
            var context = buildContext(BdName);
            var userService = buildUserService(context);

            //Act
            var users = userService.GetAllUsers();

            //Assert
            users.Should().HaveCount(0);
        }

        [Fact]
        public async Task Should_Give_One_Element()
        {
            //Arrange
            var BdName = Guid.NewGuid().ToString();
            var context = buildContext(BdName);
            var userService = buildUserService(context);
            var user = new User
            {
                Nombre = "Lucas",
                Apellido = "Fernández",
                Email = "LucasF@gmail.com",
                Password = "password",
            };
            await userService.CreateUser(user);

            //Act
            var users = userService.GetAllUsers();

            //Assert
            users.Should().HaveCount(1);
        }

        [Fact]
        public async Task Should_Give_UserAdd()
        {
            //Arrange
            var BdName = Guid.NewGuid().ToString();
            var context = buildContext(BdName);
            var userService = buildUserService(context);
            var user = new User
            {
                Nombre="Lucas",
                Apellido="Fernández",
                Email="LucasF@gmail.com",
                Password="password",
            };

            //Act
            var _user = await userService.CreateUser(user);

            //Assert
            _user.Should().Be(user);
        }

        [Fact]
        public async Task Should_Give_UpdatedUser()
        {
            //Arrange
            var BdName = Guid.NewGuid().ToString();
            var context = buildContext(BdName);
            var userService = buildUserService(context);
            var user = new User
            {
                Nombre = "Lucas",
                Apellido = "Fernández",
                Email = "LucasF@gmail.com",
                Password = "password",
            };
            await userService.CreateUser(user);
            var user2 = new User
            {
                Id = 1,
                Nombre = "Lucas Obed",
                Apellido = "Fernández",
                Email = "LucasF@gmail.com",
                Password = "password",
            };

            //Act
            var userModified = await userService.Update(user2);

            //Assert
            user.Equals(userModified);
        }

        [Fact]
        public async Task Should_Give_True_On_Delete()
        {
            //Arrange
            var BdName = Guid.NewGuid().ToString();
            var context = buildContext(BdName);
            var userService = buildUserService(context);
            var user = new User
            {
                Nombre = "Lucas",
                Apellido = "Fernández",
                Email = "LucasF@gmail.com",
                Password = "password",
            };
            await userService.CreateUser(user);

            //Act

            var response= await userService.Delete(1);
            //Assert
            response.Should().BeTrue();
        }

        [Fact]
        public async Task Should_Give_The_Request_User()
        {
            //Arrange
            var BdName = Guid.NewGuid().ToString();
            var context = buildContext(BdName);
            var userService = buildUserService(context);
            var user = new User
            {
                Nombre = "Lucas",
                Apellido = "Fernández",
                Email = "LucasF@gmail.com",
                Password = "password",
            };
            await userService.CreateUser(user);

            //Act
            var _user = await userService.GetUserByID(1);

            //Assert
            _user.Should().Be(_user);
        }

        [Fact]
        public async Task Should_Give_AppException_Because_Not_Exist()
        {
            //Arrange
            var BdName = Guid.NewGuid().ToString();
            var context = buildContext(BdName);
            var userService = buildUserService(context);

            //Act
            Func<Task<User>> action = () => userService.GetUserByID(1);

            //Assert
            await action.Should().ThrowAsync<KeyNotFoundException>();
        }
    }
}

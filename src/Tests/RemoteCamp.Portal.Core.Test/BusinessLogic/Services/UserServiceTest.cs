using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RemoteCamp.Portal.Core.BusinessLogic.Repositories;
using RemoteCamp.Portal.Core.BusinessLogic.Services;
using RemoteCamp.Portal.Core.Database.Model;
using RemoteCamp.Portal.Core.Test.Common;
using RemoteCamp.Portal.Core.Test.Helpers;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Core.Test.BusinessLogic.Services
{
    public class UserServiceTest : UnitTestBase
    {
        [Fact]
        public async void GetOrCreateByEmailAsync_UserExists_ReturnsUser()
        {
            // Arrange
            var email = "jon.snow@mail.test";
            var service = ServiceProvider.GetService<UserService>();
            var users = new[]
            {
                new User
                {
                    Id = 1,
                    Email = email,
                    CreatedAt = DateTime.UtcNow
                }
            };
            
            ServiceProvider.GetMock<IUserRepository>()
                .Setup(x => x.Query())
                .Returns(() => new AsyncQueryResult<User>(users));

            // Act
            var response = await service.GetOrCreateByEmailAsync(email);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => response.ShouldNotBeNull(),
                () => response.IsSuccess.ShouldBeTrue(),
                () => response.Value.Id.Equals(users[0].Id),
                () => response.Value.Email.Equals(users[0].Email),
                () => response.Value.CreatedAt.Equals(users[0].CreatedAt)
            );
        }
        
        [Fact]
        public async void GetOrCreateByEmailAsync_UserDoesNotExist_CreatesAndReturnsUser()
        {
            // Arrange
            var email = "jon.snow@mail.test";
            var service = ServiceProvider.GetService<UserService>();
            var users = new List<User>();
            var user = new User
            {
                Id = 1,
                Email = email,
                CreatedAt = DateTime.UtcNow
            };
            
            MockTimeService(user.CreatedAt);

            ServiceProvider.GetMock<IUserRepository>()
                .Setup(x => x.Query())
                .Returns(() => new AsyncQueryResult<User>(users));

            // Act
            var response = await service.GetOrCreateByEmailAsync(email);
            
            // Assert
            ServiceProvider.GetMock<IUserRepository>()
                .Verify(x => x.InsertAsync(It.Is(IsEqual(user))));

            this.ShouldSatisfyAllConditions(
                () => response.ShouldNotBeNull(),
                () => response.IsSuccess.ShouldBeTrue(),
                () => response.Value.Id.Equals(user.Id),
                () => response.Value.Email.Equals(user.Email),
                () => response.Value.CreatedAt.Equals(user.CreatedAt)
            );
        }
        
        public Expression<Func<User, bool>> IsEqual(User user)
        {
            return x => new CompareLogic(new ComparisonConfig
            {
                MembersToIgnore = new List<string>
                {
                    nameof(User.Id)
                }
            }).Compare(x, user).AreEqual;
        }
    }
}
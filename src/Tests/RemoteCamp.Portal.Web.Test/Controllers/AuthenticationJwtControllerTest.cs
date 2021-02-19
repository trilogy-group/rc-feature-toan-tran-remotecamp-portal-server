using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RemoteCamp.Portal.Web.Controllers;
using RemoteCamp.Portal.Web.Core.Security;
using Shouldly;
using Xunit;

namespace RemoteCamp.Portal.Web.Test.Controllers
{
    public class AuthenticationJwtControllerTest
    {

        [Theory]
        [InlineData("Bearer token", typeof(CreatedResult))]
        [InlineData("Basic token", typeof(BadRequestObjectResult))]
        [InlineData("", typeof(BadRequestObjectResult))]
        [InlineData(null, typeof(BadRequestObjectResult))]
        public void Post_DifferentData_ReturnCorrectResult(string authorizationHeader, Type resultType)
        {
            // Arrange
            var httpContext = new DefaultHttpContext();
            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            var mockJwtTokenFactory = new Mock<IJwtTokenFactory>();
            const string newToken = "newToken";
            mockJwtTokenFactory.Setup(x => x.Renew(It.IsAny<string>())).Returns(newToken);
            var controller = new AuthenticationJwtController(mockJwtTokenFactory.Object)
            {
                ControllerContext = controllerContext,
            };

            // Act
            var result = controller.Post(authorizationHeader);

            // Assert
            result.Result.ShouldBeOfType(resultType);
            if (resultType == typeof(CreatedResult))
            {
                var createdResult = result.Result as CreatedResult;
                createdResult.ShouldNotBeNull();
                createdResult.Value.ShouldBe(newToken);
            }
        }
    }
}

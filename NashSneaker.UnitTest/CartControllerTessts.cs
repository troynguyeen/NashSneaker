using HttpContextMoq;
using HttpContextMoq.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Moq;
using NashSneaker.Controllers;
using NashSneaker.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NashSneaker.UnitTest
{
    public class CartControllerTests
    {
        [Fact]
        public void AddItemToCart_WithProductId10ByUserId_ReturnsSuccessTrue()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<NashSneakerContext>()
            .UseInMemoryDatabase(databaseName: "NashSneaker")
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var context = new NashSneakerContext(options))
            {
                context.Product.Add(new Product
                {
                    Id = 10,
                    Name = "Jordan 4 G",
                    Category = new Category { Id = 1 },
                    Price = 6459000,
                    Description = "Description for Air Jordan 4 G"
                });

                context.Users.Add(new User
                {
                    Id = "fb56e6fd-0f2b-4b20-bcb0-2a877c971232",
                    FirstName = "Nguyễn",
                    LastName = "Văn Tèo",
                    UserName = "teovan.nguyen@gmail.com",
                    NormalizedUserName = "TEOVAN.NGUYEN@GMAIL.COM",
                    Email = "teovan.nguyen@gmail.com",
                    PhoneNumber = "0911111111"
                });

                context.SaveChanges();
            }

            //Arrange
            Mock<ISession> sessionMock = new Mock<ISession>();

            string userId = "fb56e6fd-0f2b-4b20-bcb0-2a877c971232";
            int productId = 10;
            int quantity = 3;
            int size = 42;
            var mockContext = new NashSneakerContext(options);
            var controller = new CartController(mockContext);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = sessionMock.Object;

            //Action
            var result = controller.AddItemToCart(userId, productId, quantity, size) as JsonResult;
            IDictionary<string, object> wrapper = new RouteValueDictionary(result.Value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(true, wrapper["success"]);
            Assert.Equal(3, wrapper["cartCounter"]);
        }

        [Fact]
        public void UpdateItemInCart_WithProductId10ByUserId_ReturnsSuccessTrue()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<NashSneakerContext>()
            .UseInMemoryDatabase(databaseName: "NashSneaker")
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var context = new NashSneakerContext(options))
            {
                context.Product.Add(new Product
                {
                    Id = 10,
                    Name = "Jordan 4 G",
                    Category = new Category { Id = 1 },
                    Price = 6459000,
                    Description = "Description for Air Jordan 4 G"
                });

                context.Users.Add(new User
                {
                    Id = "fb56e6fd-0f2b-4b20-bcb0-2a877c971232",
                    FirstName = "Nguyễn",
                    LastName = "Văn Tèo",
                    UserName = "teovan.nguyen@gmail.com",
                    NormalizedUserName = "TEOVAN.NGUYEN@GMAIL.COM",
                    Email = "teovan.nguyen@gmail.com",
                    PhoneNumber = "0911111111"
                });

                context.SaveChanges();

                context.Cart.Add(new Cart
                {
                    Id = 1,
                    TotalAmount = 0,
                    User = context.Users.SingleOrDefault(x => x.Id == "fb56e6fd-0f2b-4b20-bcb0-2a877c971232")
                });

                context.SaveChanges();

                context.CartDetail.Add(new CartDetail
                {
                    Id = 1,
                    Quantity = 1,
                    Product = context.Product.SingleOrDefault(x => x.Id == 10),
                    Cart = context.Cart.SingleOrDefault(x => x.Id == 1),
                    Size = 42
                });

                context.SaveChanges();
            }

            //Arrange
            Mock<ISession> sessionMock = new Mock<ISession>();

            string userId = "fb56e6fd-0f2b-4b20-bcb0-2a877c971232";
            int productId = 10;
            int quantity = 3;
            int size = 42;
            var mockContext = new NashSneakerContext(options);
            var controller = new CartController(mockContext);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = sessionMock.Object;

            //Action
            var result = controller.UpdateItemInCart(userId, productId, quantity, size) as JsonResult;
            IDictionary<string, object> wrapper = new RouteValueDictionary(result.Value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(true, wrapper["success"]);
            Assert.Equal(3, wrapper["cartCounter"]);
            Assert.Equal(6459000 * 3, wrapper["totalAmount"]);
        }

        [Fact]
        public void DeleteItemFromCart_WithProductId10ByUserId_ReturnsSuccessTrue()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<NashSneakerContext>()
            .UseInMemoryDatabase(databaseName: "NashSneaker")
            .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var context = new NashSneakerContext(options))
            {
                context.Product.Add(new Product
                {
                    Id = 10,
                    Name = "Jordan 4 G",
                    Category = new Category { Id = 1 },
                    Price = 6459000,
                    Description = "Description for Air Jordan 4 G"
                });

                context.Users.Add(new User
                {
                    Id = "fb56e6fd-0f2b-4b20-bcb0-2a877c971232",
                    FirstName = "Nguyễn",
                    LastName = "Văn Tèo",
                    UserName = "teovan.nguyen@gmail.com",
                    NormalizedUserName = "TEOVAN.NGUYEN@GMAIL.COM",
                    Email = "teovan.nguyen@gmail.com",
                    PhoneNumber = "0911111111"
                });

                context.SaveChanges();

                context.Cart.Add(new Cart
                {
                    Id = 1,
                    TotalAmount = 0,
                    User = context.Users.SingleOrDefault(x => x.Id == "fb56e6fd-0f2b-4b20-bcb0-2a877c971232")
                });

                context.SaveChanges();

                context.CartDetail.Add(new CartDetail
                {
                    Id = 1,
                    Quantity = 1,
                    Product = context.Product.SingleOrDefault(x => x.Id == 10),
                    Cart = context.Cart.SingleOrDefault(x => x.Id == 1),
                    Size = 42
                });

                context.SaveChanges();
            }

            //Arrange
            Mock<ISession> sessionMock = new Mock<ISession>();

            string userId = "fb56e6fd-0f2b-4b20-bcb0-2a877c971232";
            int productId = 10;
            int size = 42;
            var mockContext = new NashSneakerContext(options);
            var controller = new CartController(mockContext);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.Session = sessionMock.Object;

            //Action
            var result = controller.DeleteItemFromCart(userId, productId, size) as JsonResult;
            IDictionary<string, object> wrapper = new RouteValueDictionary(result.Value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(true, wrapper["success"]);
            Assert.Equal(0, wrapper["cartCounter"]);
            Assert.Equal(0, wrapper["totalAmount"]);
        }
    }
}

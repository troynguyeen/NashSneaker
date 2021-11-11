using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NashSneaker.BlobServices;
using NashSneaker.Controllers;
using NashSneaker.Data;
using System;
using Xunit;

namespace NashSneaker.UnitTest
{
    public class ShoppingControllerTests
    {
        [Fact]
        public async void Detail_WithProductHavingId10_ReturnsProductHavingId10()
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
                    Category = new Category {Id = 1},
                    Price = 6459000,
                    Description = "Description for Air Jordan 4 G"
                });

                context.SaveChanges();
            }

            //Arrange
            var mockBlobService = new Mock<IBlobService>();
            var mockContext = new NashSneakerContext(options);
            var controller = new ShoppingController(mockContext, mockBlobService.Object);

            //Action
            var result = await controller.Detail(10) as ViewResult;
            var product = (Product) result.ViewData.Model;

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(10, product.Id);
            Assert.Equal("Jordan 4 G", product.Name);
        }
    }
}

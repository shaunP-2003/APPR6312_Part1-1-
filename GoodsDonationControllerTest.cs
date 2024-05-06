using APPR6312_Part1_1_.Controllers;
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace APPR6312_PART1_1_.Test1
{
    [TestClass]
    public class GoodsDonationControllerTest
    {
        [TestMethod]
        public async Task AddGoods_Post_ReturnsRedirectToAction()
        { 
            // Arrange
            var goodsDonoRequest = new GoodsDonoViewM
            {
                // Populate the properties with test data
                DonationDate = DateTime.UtcNow,
                NumberOfItems = 10,
                goodsCategory = "Clothing",
                Description = "Assorted winter clothing",
                DonorName = "John Doe"
            };

            // Initialize the mock set
           var mockSet = new Mock<DbSet<goodsDonation>>();

            // Initialize the mock context
          var  mockContext = new Mock<DAFAppDataDbcontext>();
          mockContext.Setup(ctx => ctx.goodsDonations).Returns(mockSet.Object);

            // Initialize the controller with the mock context
           var controller = new GoodsDontionController(mockContext.Object);

            // Act
            var result = await controller.AddGoods(goodsDonoRequest);
            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("AddGoods", redirectToAction.ActionName);

            // Verify that the goodsDonation was added to the DbSet
            mockSet.Verify(m => m.AddAsync(It.IsAny<goodsDonation>(), It.IsAny<System.Threading.CancellationToken>()), Times.Once());

            // Verify that SaveChangesAsync was called on the DbContext
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<System.Threading.CancellationToken>()), Times.Once());
        }
    }
}

using APPR6312_Part1_1_.Controllers;
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPR6312_PART1_1_.Test1
{
    [TestClass]
    public class MonetaryDonationController
    {
        [TestMethod]
        public async Task AddMoney_Post_ReturnsRedirectToAction()
        {
            // Arrange
            var monetaryDonoRequest = new MonetaryDonoViewModel
            {
                // Populate the properties with test data
                DonationDate = DateTime.UtcNow,
                Amount = 100m, // Assuming Amount is a decimal
                DonorName = "Jane Doe"
            };

            var mockSet = new Mock<DbSet<MonetaryDonation>>();
            var mockContext = new Mock<DAFAppDataDbcontext>();
            mockContext.Setup(ctx => ctx.MonetaryDonations).Returns(mockSet.Object);

            var controller = new MonetaryDonoController(mockContext.Object);

            // Act
            var result = await controller.AddMoney(monetaryDonoRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToAction = (RedirectToActionResult)result;
            Assert.AreEqual("AddMoney", redirectToAction.ActionName);

            mockSet.Verify(m => m.AddAsync(It.IsAny<MonetaryDonation>(), It.IsAny<System.Threading.CancellationToken>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<System.Threading.CancellationToken>()), Times.Once());
        }
    }
}


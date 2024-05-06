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
    public class DisasterControllerTest
    {
        [TestMethod]
        public async Task AddDisaster_Post_ReturnsRedirectToAction()
        {
            // Arrange
            var disasterRequest = new DisasterViewM
            {
                DisasterName = "Test Disaster",
                DisasterDescription = "Test Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Location = "Test Location",
                AidType = "Test Aid"
            };

            var mockSet = new Mock<DbSet<Disaster>>();

            var mockContext = new Mock<DAFAppDataDbcontext>();
            mockContext.Setup(m => m.Disasters).Returns(mockSet.Object);

            var controller = new DisasterController(mockContext.Object);

            // Act
            var result = await controller.AddDisaster(disasterRequest);

            // Assert
            mockSet.Verify(m => m.AddAsync(It.IsAny<Disaster>(), default), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once());
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("AddDisaster", redirectResult.ActionName);
        }
    }
}
// All Test Refrences 

//The following method was taken from website
// Author: Microsoft
//Link:https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking

// The following method was taken from website
// Author: Muhammed Saleem |
//Link:https://code-maze.com/ef-core-mock-dbcontext/

// The following method was taken from website
// Author: Kamil Stadryniak
//Link:https://stackoverflow.com/questions/71587176/unit-testing-using-ef-core-inmemorydatabase-along-with-moq-mocks
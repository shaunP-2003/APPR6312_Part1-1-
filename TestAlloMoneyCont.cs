using APPR6312_Part1_1_.Controllers;
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPR6312_PART1_1_.Test1
{
    [TestClass]
    public class TestAlloMoneyCont
    {
        private DAFAppDataDbcontext _dbContext;
        private AlloMoneyController _controller;

        [TestInitialize]
        public void Initialize()
        {
            // Setup the DbContext with InMemoryDatabase
            var options = new DbContextOptionsBuilder<DAFAppDataDbcontext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDbForTesting")
                .Options;

            _dbContext = new DAFAppDataDbcontext(options);

            // Seed the database
            _dbContext.Disasters.Add(new Disaster
            {
                DisasterId = Guid.NewGuid(),
                DisasterName = "Test Disaster",
                DisasterDescription = "Test Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Location = "Test Location",
                AidType = "Food",
            });

            _dbContext.MonetaryDonations.Add(new MonetaryDonation
            {
                MoneyDonationId = Guid.NewGuid(),
                Amount = 500,
                DonorName = "John Doe",
                DonationDate = DateTime.Now,
        // ... other properties as needed
    });

            _dbContext.SaveChanges();

            // Instantiate the controller with the DbContext
            _controller = new AlloMoneyController(_dbContext);
        }

        [TestMethod]
        public async Task AllocateMoney_Get_ReturnsViewWithCorrectModel()
        {
            // Act
            var result = await _controller.AllocateMoney();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult.Model);
            Assert.IsInstanceOfType(viewResult.Model, typeof(DonoAllocationMoneyView));
        }

        [TestMethod]
        public async Task AllocateMoney_Post_ValidModel_RedirectsToAllocateMoney()
        {
            // Arrange
            var testDisaster = _dbContext.Disasters.FirstOrDefault();
            var testMoneyDonation = _dbContext.MonetaryDonations.FirstOrDefault();

            var model = new DonationAllocationMonetary
            {
                DisasterId = testDisaster.DisasterId,
                MoneyDonationId = testMoneyDonation.MoneyDonationId
            };

            // Act
            var result = await _controller.AllocateMoney(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectResult = result as RedirectToActionResult;
            Assert.AreEqual("AllocateMoney", redirectResult.ActionName);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }
    }
}

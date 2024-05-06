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
    public class InventoryControllerTest
    {

        private DAFAppDataDbcontext _context;
        private InventoryController _controller;

        [TestInitialize]
        public void setSetUp()
        {
            // // Setup in-memory database
            var options = new DbContextOptionsBuilder<DAFAppDataDbcontext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDbForTesting")
                .Options;
            _context = new DAFAppDataDbcontext(options);

            // Seed the database with test data
            _context.Disasters.Add(new Disaster
            {
                DisasterId = new Guid("1ac95bfe-404f-4347-a072-123751435fb1"), // Your existing ID
                DisasterName = "Test Disaster",
                DisasterDescription = "Test Descrip",
                StartDate= DateTime.Now,
                EndDate= DateTime.Now.AddDays(1),
                Location = "Test Location",
                AidType = "Food",
            });

        
        _context.SaveChanges();

            // Instantiate the controller with the in-memory context
            _controller = new InventoryController(_context);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public async Task AddPurchase_Get_ReturnsViewWithDisasters()
        {
            // Act
            var result = await _controller.AddPurchase();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOfType(viewResult.Model, typeof(InventoryView));
            var viewModel = viewResult.Model as InventoryView;
            Assert.IsTrue(viewModel.Disaster.Any());
        }

        [TestMethod]
        public async Task AddPurchase_Post_RedirectsToCorrectAction()
        {
            // Arrange
            var inventoryView = new InventoryView
            {
                // Populate the view model with test data
                DisasterId = new Guid("1ac95bfe-404f-4347-a072-123751435fb1"),
                DonationDate = DateTime.UtcNow,
                NumberOfItems = 5,
                goodsCategory = "Food",
                PhurchaseAmount = 100.00m
            };

            // Act
            var result = await _controller.AddPurchase(inventoryView);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.AreEqual("AddPurchase", redirectToActionResult.ActionName);
        }

        [TestMethod]
        public async Task AddPurchase_Post_AddsInventoryAndSaves()
        {
            // Arrange
            var inventoryView = new InventoryView
            {
                // Populate the view model with test data
                DisasterId = new Guid("1ac95bfe-404f-4347-a072-123751435fb1"),
                DonationDate = DateTime.UtcNow,
                NumberOfItems = 5,
                goodsCategory = "Food",
                PhurchaseAmount = 100.00m
            };

            // Act
            await _controller.AddPurchase(inventoryView);

            // Assert
            var inventoryAdded = _context.Inventory.FirstOrDefault(i => i.DisasterId == inventoryView.DisasterId);
            Assert.IsNotNull(inventoryAdded);
            Assert.AreEqual(inventoryView.NumberOfItems, inventoryAdded.NumberOfItems);
            // ... add more assertions as needed to verify the properties
        }

        //You can add more tests here to cover other cases, such as invalid model state or exceptions
    }
}


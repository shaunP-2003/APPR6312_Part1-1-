using APPR6312_Part1_1_.Controllers;
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPR6312_PART1_1_.Test1
{
    [TestClass]
    public class TestAlloController
    {
        
            private DAFAppDataDbcontext _dbContext;
            private AlloController _controller;
           

            [TestInitialize]
            public void Initialize()
            {
                var options = new DbContextOptionsBuilder<DAFAppDataDbcontext>()
                    .UseInMemoryDatabase(databaseName: "InMemoryDbForTesting")
                    .Options;

                _dbContext = new DAFAppDataDbcontext(options);

            

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

                _dbContext.goodsDonations.Add(new goodsDonation
                {
                    goodDonationId = Guid.NewGuid(),
                    goodsCategory = "Food",
                    NumberOfItems = 100,
                    Description = "Assorted winter clothing",
                    DonorName = "John Doe"
                });
            

            _dbContext.SaveChanges();

                _controller = new AlloController(_dbContext);
            // Ensure the controller is not null
            
        }

            [TestMethod]
            public async Task AllocateGoods_Get_ReturnsViewWithCorrectModel()
            {
                // Act
                var result = await _controller.AllocateGoods();

                // Assert
                Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ViewResult));
                var viewResult = result as Microsoft.AspNetCore.Mvc.ViewResult;
                Assert.IsNotNull(viewResult.Model);
                Assert.IsInstanceOfType(viewResult.Model, typeof(DonationAllocationView));
            }

            [TestMethod]
            public async Task AllocateGoods_Post_ValidModel_RedirectsToAllocateGoods()
            {
                // Arrange
                var testDisaster = _dbContext.Disasters.FirstOrDefault();
                var testGoodsDonation = _dbContext.goodsDonations.FirstOrDefault();

                var model = new DonationAllocation
                {
                    DisasterId = testDisaster.DisasterId,
                    goodDonationId = testGoodsDonation.goodDonationId
                };

                // Act
                var result = await _controller.AllocateGoods(model);

                // Assert
                Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.RedirectToActionResult));
                var redirectResult = result as Microsoft.AspNetCore.Mvc.RedirectToActionResult;
                Assert.AreEqual("AllocateGoods", redirectResult.ActionName);
            }

            [TestCleanup]
            public void Cleanup()
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Dispose();
            }
        }
    }


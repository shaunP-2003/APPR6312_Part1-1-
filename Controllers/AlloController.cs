using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APPR6312_Part1_1_.Controllers
{
    [Authorize]
    public class AlloController : Controller
    {
        private readonly DAFAppDataDbcontext _dAFAppDataDbcontext;
       // private readonly ILogger<HomeController> _logger;

        public AlloController(DAFAppDataDbcontext dAFAppDataDbcontext)
        {
            _dAFAppDataDbcontext = dAFAppDataDbcontext;
            //_logger = logger;
        }
       
        [HttpGet]
        public async Task<IActionResult> AllocateGoods()
        {

            var disasterL = await _dAFAppDataDbcontext.Disasters.ToListAsync();

            var goods = await _dAFAppDataDbcontext.goodsDonations.ToListAsync();
            // The following method was taken from Stackoverflow
            // Author: Steve Py
            //Link: https://stackoverflow.com/questions/53250194/how-to-use-my-view-model-class-and-passing-data-from-view-model-to-view-on-the-p

            var viewModel = new DonationAllocationView
            {
                DisastersView = disasterL.Select(d => new DisasterViewM
                {
                    DisasterId = d.DisasterId,
                    DisasterName = d.DisasterName,
                    DisasterDescription = d.DisasterDescription,
                    // Map other properties as needed
                }).ToList(),
                GoodsDonations = goods.Select(g => new GoodsDonoViewM
                {
                    goodDonationId = g.goodDonationId,
                    goodsCategory = g.goodsCategory,
                    NumberOfItems = g.NumberOfItems
                
                    
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> AllocateGoods(DonationAllocation model)
        {
            // Retrieve the selected disaster and goods donation IDs from the model.
            Guid disasterId = model.DisasterId;
            Guid goodsDonationId = model.goodDonationId;

            // Fetch the disaster and goods donation entities from the database using these IDs.
            Disaster disaster = _dAFAppDataDbcontext.Disasters.Find(disasterId);
            goodsDonation goods = _dAFAppDataDbcontext.goodsDonations.Find(goodsDonationId);

            if (disaster != null && goods != null)
            {
                // Create a new DonationAllocation instance and set its properties.
                DonationAllocation donationAllocation = new DonationAllocation
                {
                    AllocationId = Guid.NewGuid(),
                    DisasterId = disaster.DisasterId,
                    goodDonationId = goods.goodDonationId,
                    goodsCategory = goods.goodsCategory,
                    NumberOfItems = goods.NumberOfItems
                };

                //// Add the new DonationAllocation to the database context.
                //_dAFAppDataDbcontext.DonationsAllo.Add(donationAllocation);

                await _dAFAppDataDbcontext.DonationsAllocation.AddAsync(donationAllocation);
                await _dAFAppDataDbcontext.SaveChangesAsync();
                
            }

            // Redirect back to the AllocateGoods view or any other appropriate page.
            return RedirectToAction("AllocateGoods");
        }

    }

    
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
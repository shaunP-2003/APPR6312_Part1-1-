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
    public class AlloMoneyController : Controller
    {
        private readonly DAFAppDataDbcontext _dAFAppDataDbcontext;
        //private readonly ILogger<HomeController> _logger;

        public AlloMoneyController(DAFAppDataDbcontext dAFAppDataDbcontext)
        {
            _dAFAppDataDbcontext = dAFAppDataDbcontext;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AllocateMoney()
        {

            var disasters = await _dAFAppDataDbcontext.Disasters.ToListAsync();

            var money = await _dAFAppDataDbcontext.MonetaryDonations.ToListAsync();

            var viewModelMoney = new DonoAllocationMoneyView

            {
                //The following method was taken from Stackoverflow
                // Author: Steve Py
                //Link: https://stackoverflow.com/questions/53250194/how-to-use-my-view-model-class-and-passing-data-from-view-model-to-view-on-the-p
                Disaster = disasters.Select(d => new DisasterViewM
                {
                    DisasterId = d.DisasterId,
                    DisasterName = d.DisasterName,
                    Location= d.Location,
                    AidType= d.AidType,
                    // Other properties...
                }).ToList(),
                monetaryDonoViews = money.Select(g => new MonetaryDonoViewModel
                {
                    MoneyDonationId = g.MoneyDonationId,
                    Amount= g.Amount,
                    DonationDate= g.DonationDate,
                    DonorName= g.DonorName,


                }).ToList()
            };

            return View(viewModelMoney);
        }

        [HttpPost]

        public async Task<IActionResult> AllocateMoney(DonationAllocationMonetary model)
        {
            // Retrieve the selected disaster and goods donation IDs from the model.
            Guid disasterId = model.DisasterId;
            Guid MoneyDonationId = model.MoneyDonationId;

            // Fetch the disaster and goods donation entities from the database using these IDs.
            Disaster disaster = _dAFAppDataDbcontext.Disasters.Find(disasterId);
            MonetaryDonation money = _dAFAppDataDbcontext.MonetaryDonations.Find(MoneyDonationId);

            if (disaster != null && money != null)
            {
                // Create a new DonationAllocation instance and set its properties.
                 DonationAllocationMonetary donoAllocationMoney = new DonationAllocationMonetary
                {
                    AllocationId = Guid.NewGuid(),
                    DisasterId = disaster.DisasterId,
                     MoneyDonationId= money.MoneyDonationId,
                    Amount = money.Amount
                   
                };

                //// Add the new DonationAllocation to the database context.
                //_dAFAppDataDbcontext.DonationsAllo.Add(donationAllocation);

                await _dAFAppDataDbcontext.DonationAllocationMonetary.AddAsync(donoAllocationMoney);
                await _dAFAppDataDbcontext.SaveChangesAsync();

            }

            // Redirect back to the AllocateGoods view or any other appropriate page.
            return RedirectToAction("AllocateMoney");
        }

    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
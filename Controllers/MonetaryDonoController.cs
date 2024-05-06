using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APPR6312_Part1_1_.Controllers
{
    [Authorize]
    public class MonetaryDonoController : Controller
    {
        private readonly DAFAppDataDbcontext dAFAppDataDbcontext;

        public MonetaryDonoController(DAFAppDataDbcontext dAFAppDataDbcontext)
        {
            this.dAFAppDataDbcontext = dAFAppDataDbcontext;
        }

        [HttpGet]
        public IActionResult AddMoney()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddMoney(MonetaryDonoViewModel monetaryDonoRequest)
        {
            var monetaryDonation = new MonetaryDonation()

            {
                MoneyDonationId = Guid.NewGuid(),
                DonationDate = monetaryDonoRequest.DonationDate,
                Amount= monetaryDonoRequest.Amount,
                DonorName= monetaryDonoRequest.DonorName
                    
            };

            await dAFAppDataDbcontext.MonetaryDonations.AddAsync(monetaryDonation);
            await dAFAppDataDbcontext.SaveChangesAsync();
            return RedirectToAction("AddMoney");
        }

      
    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NHibernate.Id.Insert;

namespace APPR6312_Part1_1_.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly DAFAppDataDbcontext _dAFAppDataDbcontext;

        public InventoryController(DAFAppDataDbcontext dAFAppDataDbcontext)
        {
           _dAFAppDataDbcontext = dAFAppDataDbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> AddPurchase()
        {

            var disasterL = await _dAFAppDataDbcontext.Disasters.ToListAsync();

            // The following method was taken from Stackoverflow
            // Author: Steve Py
            //Link: https://stackoverflow.com/questions/53250194/how-to-use-my-view-model-class-and-passing-data-from-view-model-to-view-on-the-p


            var viewModel = new InventoryView
            {
                Disaster = disasterL.Select(d => new DisasterViewM
                {
                    DisasterId = d.DisasterId,
                    DisasterName = d.DisasterName,
                    Location = d.Location,
                    AidType= d.AidType,

                    // Map other properties as needed
                }).ToList()

            };
            return View(viewModel);

           }
               
        [HttpPost]
        public async Task<ActionResult>AddPurchase(InventoryView inventoryView)
        {
             // Retrieve the selected disaster and goods donation IDs from the model.
            Guid disasterId = inventoryView.DisasterId;

            // Fetch the disaster and goods donation entities from the database using these IDs.
            Disaster disaster = _dAFAppDataDbcontext.Disasters.Find(disasterId);
   

            var inventory = new Inventory()
            {
                Id = Guid.NewGuid(),
                DisasterId = disaster.DisasterId,
                DonationDate = inventoryView.DonationDate,
                NumberOfItems = inventoryView.NumberOfItems,
                goodsCategory = inventoryView.goodsCategory,
                PhurchaseAmount= inventoryView.PhurchaseAmount,
            };

            await _dAFAppDataDbcontext.Inventory.AddAsync(inventory);
            await _dAFAppDataDbcontext.SaveChangesAsync();
            return RedirectToAction("AddPurchase");
        }
    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
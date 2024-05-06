using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace APPR6312_Part1_1_.Controllers
{
    [Authorize]
    public class DisasterController : Controller
    {
        private readonly DAFAppDataDbcontext dAFAppDataDbcontext;

        public DisasterController(DAFAppDataDbcontext dAFAppDataDbcontext)
        {
            this.dAFAppDataDbcontext = dAFAppDataDbcontext;
        }

        [HttpGet]
        public IActionResult AddDisaster()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddDisaster(DisasterViewM disasterRequest)
        {
           

            
            var disaster = new Disaster()
            {
                DisasterId= Guid.NewGuid(),
                DisasterName= disasterRequest.DisasterName,
                DisasterDescription= disasterRequest.DisasterDescription,
                StartDate= disasterRequest.StartDate,
                EndDate= disasterRequest.EndDate,
                Location= disasterRequest.Location,
                AidType= disasterRequest.AidType,


            };

            await dAFAppDataDbcontext.Disasters.AddAsync(disaster);
            await dAFAppDataDbcontext.SaveChangesAsync();
            return RedirectToAction("AddDisaster");
        }

    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
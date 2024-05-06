using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace APPR6312_Part1_1_.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAFAppDataDbcontext _dAFAppDataDbcontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DAFAppDataDbcontext dAFAppDataDbcontext, ILogger<HomeController> logger)
        {
            _dAFAppDataDbcontext = dAFAppDataDbcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        [HttpGet]
        public async Task<IActionResult> DisasterView()
        {
            var disasters = await _dAFAppDataDbcontext.Disasters.ToListAsync();

            //The following method was taken from youtube
            // Author: Nick Proud
            //Link: https://youtu.be/HVuylC-XMDM?si=d6-VwztXwpvLxgjz

            var sqlQuery = @"
        SELECT 
            d.DisasterName,
            d.DisasterDescription,
            d.StartDate,
            d.EndDate,
            d.Location,
            d.AidType,
            gd.goodsCategory
        FROM 
            Disasters d
        JOIN 
            DonationsAllocation da ON d.DisasterId = da.DisasterId
        JOIN 
            GoodsDonations gd ON da.goodDonationId = gd.goodDonationId";

            // Retrieve disasters with goods allocation details
            var allocatedDisastersList = await _dAFAppDataDbcontext.Set<DisasterViewM>()
                .FromSqlRaw(sqlQuery)
                .Select(result => new DisasterViewM
                {
                    DisasterName = result.DisasterName,
                    DisasterDescription = result.DisasterDescription,
                    StartDate = result.StartDate,
                    EndDate = result.EndDate,
                    Location = result.Location,
                    AidType = result.AidType,
                    goodsCategory = result.goodsCategory,

                }) .ToListAsync();

            var sqlQuery2 = @"
        SELECT
         d.DisasterName,
            d.DisasterDescription,
            d.StartDate,
            d.EndDate,
            d.Location,
            d.AidType,
            md.Amount
        FROM 
            Disasters d
        JOIN 
            DonationAllocationMonetary dam ON d.DisasterId = dam.DisasterId
        JOIN 
            MonetaryDonations md ON dam.MoneyDonationId = md.MoneyDonationId";

            // Retrieve disasters with goods allocation details
            var currentDisastersListMon = await _dAFAppDataDbcontext.Set<DiastersViewMonetrayM>()
                .FromSqlRaw(sqlQuery2)
                .Select(result => new DiastersViewMonetrayM
                {
                    DisasterName = result.DisasterName,
                    DisasterDescription = result.DisasterDescription,
                    StartDate = result.StartDate,
                    EndDate = result.EndDate,
                    Location = result.Location,
                    AidType = result.AidType,
                    Amount = result.Amount,
                }).ToListAsync();

            //The following method was taken from Website
            // Author: Marcus Rath
            //Link: https://blog.matrixpost.net/using-list-tuples-in-c/
            // Combine the two lists into a tuple or a custom ViewModel
            var combinedViewModel = new Tuple<List<Disaster>, List<DisasterViewM>,List<DiastersViewMonetrayM>>(disasters, allocatedDisastersList, currentDisastersListMon);

            // Pass the combined view model to the view
            return View(combinedViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> InventoryView()
        {
            //The following method was taken from Stackoverflow
            // Author: hemantsharma
            //Link: https://stackoverflow.com/questions/38931374/how-to-perform-sum-operation-in-entity-framework
            // refrence 
            var totalMoneyDono = _dAFAppDataDbcontext.MonetaryDonations.Sum(m => m.Amount);
            var totalGoodsPurchase = _dAFAppDataDbcontext.Inventory.Sum(p => p.PhurchaseAmount);

            //The following method was taken from Website
            // Author: Abhimanyu K Vatsa
            //Link: https://www.c-sharpcorner.com/UploadFile/abhikumarvatsa/various-ways-to-pass-data-from-controller-to-view-in-mvc/


            var availableMoney = totalMoneyDono - totalGoodsPurchase;
            ViewData["availableMoney"] = availableMoney;
            
            ViewData["totalMoneyDono"] = totalMoneyDono;
           
            var purchases = await _dAFAppDataDbcontext.Inventory.ToListAsync();

            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> GoodsDonoView()
        {
            
                var goods = await _dAFAppDataDbcontext.goodsDonations.ToListAsync();
                return View(goods);
            
            
        }
        [HttpGet]
        public async Task<IActionResult> MonetaryView()
        {
            var monetaries = await _dAFAppDataDbcontext.MonetaryDonations.ToListAsync();
            return View(monetaries);
        }
    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
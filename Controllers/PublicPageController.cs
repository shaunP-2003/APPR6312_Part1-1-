using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APPR6312_Part1_1_.Controllers
{
    [AllowAnonymous]
    public class PublicPageController : Controller
    {
        private readonly DAFAppDataDbcontext _dAFAppDataDbcontext;
        private readonly ILogger<HomeController> _logger;

        public PublicPageController(DAFAppDataDbcontext dAFAppDataDbcontext, ILogger<HomeController> logger)
        {
            _dAFAppDataDbcontext = dAFAppDataDbcontext;
            _logger = logger;
        }
        // GET: PublicPageController
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Public()
        {    //The following method was taken from Stackoverflow
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

            var totalGoodsDono = _dAFAppDataDbcontext.goodsDonations.Sum(m => m.NumberOfItems);
            ViewData["totalGoodsDono"] = totalGoodsDono;


            var currentDate = DateTime.Now;

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
            GoodsDonations gd ON da.goodDonationId = gd.goodDonationId
        WHERE 
        d.StartDate <= @currentDate AND d.EndDate >= @currentDate";

            // Retrieve disasters with goods allocation details
            var currentDisastersListGoods = await _dAFAppDataDbcontext.Set<DisasterViewM>()
                .FromSqlRaw(sqlQuery, new SqlParameter("@currentDate", currentDate))
                .Select(result => new DisasterViewM
                {
                    DisasterName = result.DisasterName,
                    DisasterDescription = result.DisasterDescription,
                    StartDate = result.StartDate,
                    EndDate = result.EndDate,
                    Location = result.Location,
                    AidType = result.AidType,
                    goodsCategory = result.goodsCategory,
                }).ToListAsync();


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
            MonetaryDonations md ON dam.MoneyDonationId = md.MoneyDonationId
        WHERE 
        d.StartDate <= @currentDate AND d.EndDate >=@currentDate";

            // Retrieve disasters with goods allocation details
            var currentDisastersListMon = await _dAFAppDataDbcontext.Set<DiastersViewMonetrayM>()
                .FromSqlRaw(sqlQuery2, new SqlParameter("@currentDate", currentDate))
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


            // The following method was taken from Website
            // Author: Marcus Rath
            //Link: https://blog.matrixpost.net/using-list-tuples-in-c/
            // Combine the two lists into a tuple or a custom ViewModel
            // Combine the two lists into a tuple or a custom ViewModel
            var combinedViewModel = new Tuple<List<DiastersViewMonetrayM>, List<DisasterViewM>>(currentDisastersListMon, currentDisastersListGoods);

            // Pass the combined view model to the view
            return View(combinedViewModel);
        }
    }
}

using APPR6312_Part1_1_.Models.Domain;
using APPR6312_Part1_1_.Data;
using APPR6312_Part1_1_.Models.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace APPR6312_Part1_1_.Controllers
{
    [Authorize]
    public class GoodsDontionController : Controller
    {
        private readonly DAFAppDataDbcontext dAFAppDataDbcontext;

        public GoodsDontionController(DAFAppDataDbcontext dAFAppDataDbcontext) 
        {
            this.dAFAppDataDbcontext = dAFAppDataDbcontext;
        }
        [HttpGet]
        public IActionResult AddGoods()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddGoods(GoodsDonoViewM goodsDonoRequest)
        {
            var goodDono = new goodsDonation()
            {
                goodDonationId = Guid.NewGuid(),
                DonationDate = goodsDonoRequest.DonationDate,
                NumberOfItems = goodsDonoRequest.NumberOfItems,
                goodsCategory = goodsDonoRequest.goodsCategory,
                Description = goodsDonoRequest.Description,
                DonorName = goodsDonoRequest.DonorName

            };

            await dAFAppDataDbcontext.goodsDonations.AddAsync(goodDono);
            await dAFAppDataDbcontext.SaveChangesAsync();
            return RedirectToAction("AddGoods");
        }
    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
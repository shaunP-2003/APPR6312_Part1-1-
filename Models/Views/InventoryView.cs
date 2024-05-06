using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312_Part1_1_.Models.Views
{
    public class InventoryView
    {
        public Guid Id { get; set; }
        public Guid DisasterId { get; set; }

        public DateTime DonationDate { get; set; }
        public int NumberOfItems { get; set; }
        public string goodsCategory { get; set; }
        public decimal PhurchaseAmount { get; set; }

        public List<DisasterViewM> Disaster { get; set; }
        public List<MonetaryDonoViewModel> monetaryDonoViews { get; set; }
    }
}

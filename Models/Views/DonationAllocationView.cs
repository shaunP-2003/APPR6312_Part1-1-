using APPR6312_Part1_1_.Models.Domain;

namespace APPR6312_Part1_1_.Models.Views
{
    public class DonationAllocationView
    {
        public Guid DisasterId { get; set; } // The ID of the selected disaster
        public List<DisasterViewM> DisastersView{ get; set; } // List of available disasters
        public Guid goodDonationId { get; set; } // The ID of the selected goods donation
        public List<GoodsDonoViewM> GoodsDonations { get; set; } // List of available goods donations




    }
    
}
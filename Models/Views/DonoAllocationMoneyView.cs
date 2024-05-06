namespace APPR6312_Part1_1_.Models.Views
{
    public class DonoAllocationMoneyView
    {
        public Guid DisasterId { get; set; } // The ID of the selected disaster
        public List<DisasterViewM> Disaster { get; set; } // List of available disasters
        public Guid MoneyDonationId { get; set; }
        public List<MonetaryDonoViewModel> monetaryDonoViews { get; set; } // List of available goods donations
    }
}

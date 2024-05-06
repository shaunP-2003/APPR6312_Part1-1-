namespace APPR6312_Part1_1_.Models.Views
{
    public class DiastersViewMonetrayM
    {
        public Guid DisasterId { get; set; }
        public string DisasterName { get; set; }
        public string DisasterDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string AidType { get; set; }
        public decimal Amount { get; set; }
    }
}

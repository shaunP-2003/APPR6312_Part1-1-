using APPR6312_Part1_1_.Models.Domain;

namespace APPR6312_Part1_1_.Models.Views
{
    public class DisasterViewM
    {
        public Guid DisasterId { get; set; }
        public string DisasterName { get; set; }
        public string DisasterDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string AidType { get; set; }
        public string goodsCategory { get; set; }

        

    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
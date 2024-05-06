using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312_Part1_1_.Models.Domain
{
    public class Disaster
    {

        [Key]
        public Guid DisasterId { get; set; }
        public string DisasterName { get; set; }
        public string DisasterDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string AidType { get; set; }

        public List<DonationAllocation> donationAllocations  { get; set; }

        public List<DonationAllocationMonetary> donationAllocationMonetaries { get; set; }

        public List<Inventory> Inventory { get; set; }


    }

}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO
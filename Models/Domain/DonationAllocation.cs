using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312_Part1_1_.Models.Domain
{
    public class DonationAllocation
    {
        [Key]
        public Guid AllocationId { get; set; }

        public Guid DisasterId { get; set; }

        public Guid goodDonationId { get; set; }

        public string goodsCategory { get; set; }
        public int NumberOfItems { get; set; }

        
        [ForeignKey("DisasterId")]

        public Disaster Disaster { get; set; }

        [ForeignKey("goodDonationId")]
        public goodsDonation goodsDonation { get; set; }


       
    }
}

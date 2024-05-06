using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312_Part1_1_.Models.Domain
{
    public class DonationAllocationMonetary
    {
        [Key]
        public Guid AllocationId { get; set; }

        public Guid DisasterId { get; set; }

        public Guid MoneyDonationId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [ForeignKey("DisasterId")]

        public Disaster Disaster { get; set; }

        [ForeignKey("MoneyDonationId")]
        public MonetaryDonation monetaryDonation { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312_Part1_1_.Models.Domain
{
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DisasterId { get; set; }

        public DateTime DonationDate { get; set; }

        public int NumberOfItems { get; set; }
        public string goodsCategory { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal PhurchaseAmount { get; set; }


        [ForeignKey("DisasterId")]

        public Disaster Disaster { get; set; }

       
    }
}
